using System;
using Gtk;
using Tatooine;
using System.Collections.Generic;

namespace TatooineDesktop
{
	public partial class ArchiveWindow : Gtk.Window
	{

		protected PasswordArchive _archive;

		protected ListStore _groupStore;

		public ArchiveWindow (PasswordArchive archive) : 
				base(Gtk.WindowType.Toplevel)
		{
			_archive = archive;

			this.Build ();
			this.setupGroupsTree();
			this.loadArchive();
		}

		public void close()
		{
			Application.Quit ();
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
			foreach (KeyValuePair<string, string> group in groups) {
				_groupStore.AppendValues(group.Value);
			}
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

