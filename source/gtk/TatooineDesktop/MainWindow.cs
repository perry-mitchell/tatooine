using System;
using Gtk;

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

}
