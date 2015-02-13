using System;
using Gtk;
using System.IO;
using TatooineDesktop;
using System.Security;
using Tatooine;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	public void close() {
		Application.Quit ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		this.close ();
		a.RetVal = true;
	}

	protected void closeButtonClicked (object sender, EventArgs e)
	{
		this.close ();
	}

	protected void openArchiveClicked (object sender, EventArgs e)
	{
		string archiveFilePath = archiveFilePathEntry.Text;
		if (File.Exists (archiveFilePath)) {
			SecureString password = Tatooine.Tools.Encoding.stringToSecureString(archivePasswordEntry.Text);
			archivePasswordEntry.Text = "";
			PasswordArchive archive = PasswordArchive.createWithFile(archiveFilePath, password);
			ArchiveWindow archiveWindow = new ArchiveWindow(archive);
			this.Hide();
			archiveWindow.Show ();
		} else {
			GUIHelper.showError("Archive file", "The file specified does not exist, or is not accessible.");
		}
	}	

	protected void createArchiveButtonClicked (object sender, EventArgs e)
	{
		if (newPasswordEntry.Text.Length > 0) {
			SecureString password = Tatooine.Tools.Encoding.stringToSecureString(newPasswordEntry.Text);
			newPasswordEntry.Text = "";
			PasswordArchive newArchive = PasswordArchive.createNew(password);
			ArchiveWindow archiveWindow = new ArchiveWindow(newArchive);
			this.Hide();
			archiveWindow.Show ();
		} else {
			GUIHelper.showError("New password", "You must enter a password for the new archive.");
		}
	}



}
