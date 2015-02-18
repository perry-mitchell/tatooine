using System;

namespace TatooineDesktop
{
	public partial class UserInputDialog : Gtk.Dialog
	{

		public enum UserInputAction {Cancel, OK};

		protected Action<UserInputAction, string> _callback;

		public UserInputDialog (string title, string message, Action<UserInputAction, string> callback)
		{
			this.Build ();

			_callback = callback;

			this.Title = title;
			messageLabel.Text = message;
		}

		protected void cancelButtonClicked (object sender, EventArgs e)
		{
			_callback(UserInputAction.Cancel, "");
			this.Destroy();
		}		

		protected void okButtonClicked (object sender, EventArgs e)
		{
			_callback(UserInputAction.OK, textEntry.Text);
			this.Destroy();
		}

		public void setText(string text)
		{
			textEntry.Text = text;
		}

	}
}

