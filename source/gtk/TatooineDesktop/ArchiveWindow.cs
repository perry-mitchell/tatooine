using System;
using Tatooine;

namespace TatooineDesktop
{
	public partial class ArchiveWindow : Gtk.Window
	{

		protected PasswordArchive _archive;

		public ArchiveWindow (PasswordArchive archive) : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.loadArchive();
		}

		protected void loadArchive() {

		}

	}
}

