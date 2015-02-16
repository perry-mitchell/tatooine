using System;
using System.Collections.Generic;

namespace TatooineDesktop {

	public partial class NewEntryDialog : Gtk.Dialog {

		public enum NewEntryAction {Cancel, OK};

		protected Action<NewEntryAction, Dictionary<string, string>> _callback;

		public NewEntryDialog (Action<NewEntryAction, Dictionary<string, string>> callback) {
			this.Build ();

			_callback = callback;
		}

		protected void cancelButtonClicked (object sender, EventArgs e) {
			_callback(NewEntryAction.Cancel, null);
			this.Destroy();
		}

		protected void okButtonClicked (object sender, EventArgs e) {
			Dictionary<string, string> values = new Dictionary<string, string>();
			values.Add("title", titleEntry.Text);
			values.Add("username", usernameEntry.Text);
			values.Add("password", passwordEntry.Text);
			values.Add("uri", uriEntry.Text);
			_callback(NewEntryAction.OK, values);
			this.Destroy();
		}


	}

}

