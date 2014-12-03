using System;
using Gtk;

public partial class PasswordEntryDialog : Gtk.Dialog
{
	public PasswordEntryDialog () : base ()
	{
		Build ();
	}

	public string getPassword() {
		return this.passwordEntry.Text;
	}
}

