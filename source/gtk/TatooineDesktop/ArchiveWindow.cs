using System;

namespace TatooineDesktop
{
	public partial class ArchiveWindow : Gtk.Window
	{
		public ArchiveWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

