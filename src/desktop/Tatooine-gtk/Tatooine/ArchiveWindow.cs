using System;
using System.Security;
using System.Collections.Generic;
using Gtk;
using Tatooine;

public partial class ArchiveWindow: Gtk.Window
{

	private string archiveFilename;
	private PasswordArchive archive;

	private List<string> groupHashes;
	private ListStore groupsListStore;
	private ListStore entriesListStore;

	public ArchiveWindow (string archiveFilePath, SecureString password) : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		archiveFilename = archiveFilePath;
		groupHashes = new List<string>();
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

		entriesView.AppendColumn("Title", new CellRendererText(), "text", 0);

		entriesListStore = new ListStore(typeof (string));
		entriesView.Model = entriesListStore;

	}

	protected void populateInterface ()
	{
		Dictionary<string, string> groups = archive.getGroups ();
		Dictionary<string, string>.ValueCollection valueColl = groups.Values;
		Dictionary<string, string>.KeyCollection keyColl = groups.Keys;
		groupHashes.Clear ();
		foreach (string groupName in valueColl) {
			groupsListStore.AppendValues (groupName);
		}
		foreach (string groupHash in keyColl) {
			groupHashes.Add (groupHash);
		}
	}

	protected void populateEntriesForGroup (string hash)
	{
		entriesListStore.Clear();
		List<PasswordEntry> entries = archive.getEntriesForGroup (hash);
		foreach (PasswordEntry pe in entries) {
			entriesListStore.AppendValues(pe.getTitle());
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		//a.RetVal = true;
	}

	protected void groupItemSelected (object o, EventArgs args)
	{
		TreeSelection selection = (o as TreeView).Selection;
		TreeModel model;
		TreeIter iter;

		if (selection.GetSelected (out model, out iter)) {
			int index = model.GetPath(iter).Indices[0];
			string hash = groupHashes[index];
			populateEntriesForGroup(hash);
			//Console.WriteLine ("Selected: " + model.GetValue(iter, 0) + " ({0})", index);
		}
	}


}
