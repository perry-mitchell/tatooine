using System;
using Gtk;

namespace TatooineDesktop
{
	public class GUIHelper
	{

		public GUIHelper ()
		{
			throw new NotImplementedException("Do not instantiate GUIHelper");
		}

		public static void showError(string title, string message)
		{
			MessageDialog md = new MessageDialog (null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, message);
            md.Run ();
            md.Destroy();
		}

	}
}

