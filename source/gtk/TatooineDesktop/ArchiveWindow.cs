using System;
using Gtk;
using Tatooine;
using System.Collections.Generic;

namespace TatooineDesktop
{
	public partial class ArchiveWindow : Gtk.Window
	{

		protected PasswordArchive _archive;
		protected string _archivePath;

		protected List<string> _loadedGroupNames;
		protected List<PasswordEntry> _loadedEntries;
		protected string _selectedGroupHash;
		protected ListStore _groupStore;
		protected ListStore _entriesStore;

		public ArchiveWindow (PasswordArchive archive) : 
				base(Gtk.WindowType.Toplevel)
		{
			_archive = archive;
			_archivePath = "";
			_loadedGroupNames = new List<string>();

			this.Build ();
			this.setupGroupsTree();
			this.setupEntriesTree();
			this.loadArchive();
		}

		public void close()
		{
			Application.Quit ();
		}

		protected void createNewEntryActivated (object sender, EventArgs e)
		{
			UserInputDialog uid = new UserInputDialog("Entry title", "Enter the title of the new entry:", createNewEntryTitleEntered);
			uid.Show();
		}

		protected void createNewEntryTitleEntered (UserInputDialog.UserInputAction actionTaken, string entryName)
		{
			if (actionTaken == UserInputDialog.UserInputAction.OK) {
				if (entryName.Length > 0) {
					_archive.createEntry(entryName, _selectedGroupHash);
					loadGroup(_selectedGroupHash);
				} else {
					GUIHelper.showError("Entry title", "You must enter an entry title.");
				}
			}
		}

		protected void createNewGroupActivated (object sender, EventArgs e)
		{
			UserInputDialog uid = new UserInputDialog("Group name", "Enter the name of the new group:", createNewGroupNameEntered);
			uid.Show();
		}

		protected void createNewGroupNameEntered (UserInputDialog.UserInputAction actionTaken, string groupName)
		{
			if (actionTaken == UserInputDialog.UserInputAction.OK) {
				if (groupName.Length > 0) {
					_archive.createGroup(groupName);
					loadArchive();
				} else {
					GUIHelper.showError("Group name", "You must enter a group name.");
				}
			}
		}

		protected void loadArchive ()
		{
			// Groups
			_groupStore.Clear ();
			Dictionary<string, string> groups = _archive.getGroups ();
			_loadedGroupNames.Clear();
			foreach (KeyValuePair<string, string> group in groups) {
				_groupStore.AppendValues(group.Value);
				_loadedGroupNames.Add (group.Value);
			}
		}

		protected void loadGroup (string groupHash)
		{
			_selectedGroupHash = groupHash;
			_entriesStore.Clear ();
			_loadedEntries = _archive.getEntriesForGroup (groupHash);
			foreach (PasswordEntry entry in _loadedEntries) {
				_entriesStore.AppendValues(entry.getTitle(), entry.getProperty("username"));
			}
		}

		protected void rowSelected (object sender, EventArgs e)
		{
			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;

			if (selection.GetSelected (out model, out iter)) {
				int index = model.GetPath (iter).Indices [0];
				string groupName = _loadedGroupNames[index];
				string groupHash = _archive.getGroupHashForName(groupName);
				loadGroup(groupHash);
			}
		}

		protected void saveArchive ()
		{
			if (_archivePath.Length > 0) {
				_archive.writeToFile(_archivePath);
			} else {
				Gtk.FileChooserDialog fcd = new Gtk.FileChooserDialog(
					"Save archive",
					this, FileChooserAction.Save,
					"Cancel",ResponseType.Cancel, "Open",ResponseType.Accept
				);
				if (fcd.Run() == (int)ResponseType.Accept) {
					_archivePath = fcd.Filename;
					_archive.writeToFile(_archivePath);
				}
				fcd.Destroy();
			}
		}

		protected void saveArchiveActivated (object sender, EventArgs e)
		{
			saveArchive();
		}

		public void setArchivePath(string path)
		{
			_archivePath = path;
		}

		protected void setupEntriesTree ()
		{
			Gtk.TreeViewColumn entryNameCol = new Gtk.TreeViewColumn ();
        	entryNameCol.Title = "Entry";

			Gtk.TreeViewColumn userNameCol = new Gtk.TreeViewColumn ();
        	userNameCol.Title = "Username";

			Gtk.CellRendererText entryNameCell = new Gtk.CellRendererText ();
        	entryNameCol.PackStart (entryNameCell, true);

			Gtk.CellRendererText userNameCell = new Gtk.CellRendererText ();
        	userNameCol.PackStart (userNameCell, true);
 
			entriesTree.AppendColumn(entryNameCol);
			entriesTree.AppendColumn(userNameCol);
			entryNameCol.AddAttribute (entryNameCell, "text", 0);
			userNameCol.AddAttribute(userNameCell, "text", 1);
 
       		_entriesStore = new Gtk.ListStore(typeof (string), typeof (string));
 
			entriesTree.Model = _entriesStore;
		}

		protected void setupGroupsTree ()
		{
			Gtk.TreeViewColumn groupNameCol = new Gtk.TreeViewColumn ();
        	groupNameCol.Title = "Groups";

			Gtk.CellRendererText groupNameCell = new Gtk.CellRendererText ();
        	groupNameCol.PackStart (groupNameCell, true);
 
 	        groupTree.AppendColumn(groupNameCol);
			groupNameCol.AddAttribute (groupNameCell, "text", 0);
 
       		_groupStore = new Gtk.ListStore(typeof (string));
 
			groupTree.Model = _groupStore;
		}

		protected void windowClose (object o, Gtk.DeleteEventArgs args)
		{
			this.close ();
			args.RetVal = true;
		}		

	}
}

