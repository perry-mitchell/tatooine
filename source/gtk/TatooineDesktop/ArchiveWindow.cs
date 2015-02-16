using System;
using Gtk;
using Tatooine;
using System.Collections.Generic;

namespace TatooineDesktop
{
	public partial class ArchiveWindow : Gtk.Window
	{
		private const int MOUSE_BUTTON_RIGHT = 3;

		protected PasswordArchive _archive;
		protected string _archivePath;

		protected PasswordEntry _activatedPasswordEntry;
		protected string _activatedPasswordEntryProperty;
		protected List<string> _loadedGroupNames;
		protected List<PasswordEntry> _loadedEntries;
		protected List<string> _loadedEntryProperties;
		protected string _selectedGroupHash;
		protected ListStore _groupStore;
		protected ListStore _entriesStore;
		protected ListStore _entryPropertiesStore;

		public ArchiveWindow (PasswordArchive archive) : base(Gtk.WindowType.Toplevel)
		{
			_archive = archive;
			_archivePath = "";
			_activatedPasswordEntryProperty = "";
			_loadedGroupNames = new List<string>();
			_loadedEntryProperties = new List<string>();

			this.Build ();
			this.setupGroupsTree();
			this.setupEntriesTree();
			this.setupEntryPropertiesTree();
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

		protected void createNewGroup() {
			UserInputDialog uid = new UserInputDialog("Group name", "Enter the name of the new group:", createNewGroupNameEntered);
			uid.Show();
		}

		protected void createNewGroupActivated (object sender, EventArgs e) {
			createNewGroup();
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

		protected void entryPropertyRowActivated (object o, RowActivatedArgs args)
		{
			TreeSelection selection = (o as TreeView).Selection;
			TreeModel model;
			TreeIter iter;

			if (selection.GetSelected (out model, out iter)) {
				int index = model.GetPath (iter).Indices [0];
				_activatedPasswordEntryProperty = _loadedEntryProperties[index];
				UserInputDialog uid = new UserInputDialog("Set value", "Set: '" + _activatedPasswordEntryProperty + "':", entryPropertyRowEdited);
				uid.setText(_activatedPasswordEntry.getProperty(_activatedPasswordEntryProperty));
				uid.Show ();
			}
		}

		protected void entryPropertyRowEdited (UserInputDialog.UserInputAction actionTaken, string newValue)
		{
			if (actionTaken == UserInputDialog.UserInputAction.OK) {
				if ((_activatedPasswordEntry != null) && (_activatedPasswordEntryProperty.Length > 0)) {
					_activatedPasswordEntry.setProperty(_activatedPasswordEntryProperty, newValue);
					loadEntry(_activatedPasswordEntry);
				}
			}
		}

		protected void entryRowSelected (object sender, EventArgs e)
		{
			TreeSelection selection = (sender as TreeView).Selection;
			TreeModel model;
			TreeIter iter;

			if (selection.GetSelected (out model, out iter)) {
				int index = model.GetPath (iter).Indices [0];
				PasswordEntry entry = _loadedEntries[index];
				loadEntry(entry);
			}
		}

		protected void exitButtonActivated (object sender, EventArgs e)
		{
			// todo: ask for save
			close ();
		}

		[ GLib.ConnectBefore ]
		protected void groupListButtonPress (object o, ButtonPressEventArgs args) {
			if (args.Event.Button == MOUSE_BUTTON_RIGHT) {
				showGroupsPopup();
			}
		}

		protected void groupRowSelected (object sender, EventArgs e)
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

		protected void loadEntry (PasswordEntry entry)
		{
			_activatedPasswordEntry = entry;
			_activatedPasswordEntryProperty = "";
			_entryPropertiesStore.Clear ();
			_loadedEntryProperties.Clear ();
			if (entry == null) {
				return;
			}
			Dictionary<string, string> propertyDict = entry.getProperties();
			foreach (KeyValuePair<string, string> prop in propertyDict) {
				_entryPropertiesStore.AppendValues(prop.Key, prop.Value);
				_loadedEntryProperties.Add (prop.Key);
			}
		}

		protected void loadGroup (string groupHash)
		{
			loadEntry(null);
			_selectedGroupHash = groupHash;
			_entriesStore.Clear ();
			_loadedEntries = _archive.getEntriesForGroup (groupHash);
			foreach (PasswordEntry entry in _loadedEntries) {
				_entriesStore.AppendValues(entry.getTitle(), entry.getProperty("username"));
			}
		}

		protected void saveArchive (bool saveAs = false)
		{
			if ((_archivePath.Length > 0) && !saveAs) {
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

		protected void saveAsButtonActivated (object sender, EventArgs e)
		{
			saveArchive(true);
		}

		protected void saveArchiveActivated (object sender, EventArgs e)
		{
			saveArchive();
		}

		public void setArchivePath(string path)
		{
			_archivePath = path;
		}

		protected void setupEntryPropertiesTree ()
		{
			Gtk.TreeViewColumn propertyCol = new Gtk.TreeViewColumn ();
        	propertyCol.Title = "Property";

			Gtk.TreeViewColumn valueCol = new Gtk.TreeViewColumn ();
        	valueCol.Title = "Value";

			Gtk.CellRendererText propertyCell = new Gtk.CellRendererText ();
        	propertyCol.PackStart (propertyCell, true);

			Gtk.CellRendererText valueCell = new Gtk.CellRendererText ();
        	valueCol.PackStart (valueCell, true);
 
			entryPropertiesTree.AppendColumn(propertyCol);
			entryPropertiesTree.AppendColumn(valueCol);
			propertyCol.AddAttribute(propertyCell, "text", 0);
			valueCol.AddAttribute(valueCell, "text", 1);
 
       		_entryPropertiesStore = new Gtk.ListStore(typeof (string), typeof (string));
 
			entryPropertiesTree.Model = _entryPropertiesStore;
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

		protected void showGroupsPopup ()
		{
			Gtk.Menu groupsPopup = new Gtk.Menu();

			Gtk.MenuItem newGroupItem = new Gtk.MenuItem("Create new group");
			newGroupItem.Activated += delegate(object sender, EventArgs e) {
				createNewGroup();
			};
			groupsPopup.Append(newGroupItem);

			groupsPopup.ShowAll();
			groupsPopup.Popup();
		}

		protected void windowClose (object o, Gtk.DeleteEventArgs args)
		{
			this.close ();
			args.RetVal = true;
		}		
			
	}
}

