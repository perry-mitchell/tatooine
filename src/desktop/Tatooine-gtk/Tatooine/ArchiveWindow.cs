using System;
using System.Security;
using System.Collections.Generic;
using Gtk;
using Tatooine;

public partial class ArchiveWindow: Gtk.Window
{

	private string archiveFilename;
	private PasswordArchive archive;

	private ListStore groupsListStore;

	public ArchiveWindow (string archiveFilePath, SecureString password) : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		archiveFilename = archiveFilePath;
		bool loaded = false;
		try {
			archive = PasswordArchive.createFromFileUsingPassword(archiveFilename, password);
			loaded = true;
		} catch (Exception) {
			MessageDialog md = new MessageDialog (this, 
                DialogFlags.DestroyWithParent, MessageType.Error, 
                ButtonsType.Close, "Incorrect password");
			md.Run ();
			md.Destroy ();
			this.Destroy ();
		}
		if (loaded) {
			setupInterface();
			populateInterface();
		}
	}

	protected void setupInterface() {
		TreeViewColumn groupNameCol = new TreeViewColumn();
		groupNameCol.Title = "Groups";
		CellRendererText groupNameCell = new CellRendererText();
		groupNameCol.PackStart(groupNameCell, true);
		groupsView.AppendColumn(groupNameCol);

		groupNameCol.AddAttribute(groupNameCell, "text", 0);
		groupsListStore = new ListStore(typeof (string));
		groupsView.Model = groupsListStore;
	}

	protected void populateInterface ()
	{
		Dictionary<string, string> groups = archive.getGroups ();
		Dictionary<string, string>.ValueCollection valueColl = groups.Values;
		foreach (string groupName in valueColl) {
			groupsListStore.AppendValues(groupName);
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		//a.RetVal = true;
	}

}
