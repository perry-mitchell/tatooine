using System;
using Gtk;

public partial class ArchiveWindow: Gtk.Window
{

	private string archiveFilename;

	public ArchiveWindow (string archiveFilePath) : base (Gtk.WindowType.Toplevel)
	{
		archiveFilename = archiveFilePath;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		//Application.Quit ();
		//a.RetVal = true;
	}

}
