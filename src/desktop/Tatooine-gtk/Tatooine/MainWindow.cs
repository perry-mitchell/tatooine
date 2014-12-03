using System;
using Gtk;
using System.Security;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void chooseClicked (object sender, EventArgs e)
	{
		FileChooserDialog chooser = new FileChooserDialog ("Select the archive",
		                                                  this,
		                                                  FileChooserAction.Open,
		                                                  "Cancel", ResponseType.Cancel,
		                                                  "Open", ResponseType.Accept);
		if (chooser.Run () == (int)ResponseType.Accept) {
			fileEntry.Text = chooser.Filename;
		}

		chooser.Destroy();
	}

	protected void openClicked (object sender, EventArgs e)
	{
		if (fileEntry.Text.Length <= 0) {
			MessageDialog md = new MessageDialog(this, 
                DialogFlags.DestroyWithParent, MessageType.Warning, 
                ButtonsType.Close, "Please select a file first");
            md.Run();
            md.Destroy();
		} else {
			this.Hide();
			//ArchiveWindow aw = new ArchiveWindow(fileEntry.Text);
			//aw.Show();
			PasswordEntryDialog ped = new PasswordEntryDialog();
			ped.Run();
			string pass = ped.getPassword();
			SecureString password = new SecureString();
			foreach (char c in pass) {
			    password.AppendChar(c);
			}
			ped.Destroy();
			ArchiveWindow aw = new ArchiveWindow(fileEntry.Text, password);
			aw.Show ();
		}
	}


}
