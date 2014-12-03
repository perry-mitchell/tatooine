
// This file has been generated by the GUI designer. Do not modify.

public partial class PasswordEntryDialog
{
	private global::Gtk.VBox vbox3;
	private global::Gtk.Label label2;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.Label label3;
	private global::Gtk.Entry passwordEntry;
	private global::Gtk.Button buttonCancel;
	private global::Gtk.Button buttonOk;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget PasswordEntryDialog
		this.Name = "PasswordEntryDialog";
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Internal child PasswordEntryDialog.VBox
		global::Gtk.VBox w1 = this.VBox;
		w1.Name = "dialog1_VBox";
		w1.BorderWidth = ((uint)(2));
		// Container child dialog1_VBox.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Enter the password for the archive");
		this.vbox3.Add (this.label2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.HeightRequest = 100;
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Password:");
		this.fixed1.Add (this.label3);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label3]));
		w3.X = 9;
		w3.Y = 32;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.passwordEntry = new global::Gtk.Entry ();
		this.passwordEntry.WidthRequest = 223;
		this.passwordEntry.CanFocus = true;
		this.passwordEntry.Name = "passwordEntry";
		this.passwordEntry.IsEditable = true;
		this.passwordEntry.Visibility = false;
		this.passwordEntry.InvisibleChar = '•';
		this.fixed1.Add (this.passwordEntry);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.passwordEntry]));
		w4.X = 83;
		w4.Y = 27;
		this.vbox3.Add (this.fixed1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.fixed1]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		w1.Add (this.vbox3);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox3]));
		w6.Position = 0;
		// Internal child PasswordEntryDialog.ActionArea
		global::Gtk.HButtonBox w7 = this.ActionArea;
		w7.Name = "dialog1_ActionArea";
		w7.Spacing = 10;
		w7.BorderWidth = ((uint)(5));
		w7.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
		// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
		this.buttonCancel = new global::Gtk.Button ();
		this.buttonCancel.CanDefault = true;
		this.buttonCancel.CanFocus = true;
		this.buttonCancel.Name = "buttonCancel";
		this.buttonCancel.UseStock = true;
		this.buttonCancel.UseUnderline = true;
		this.buttonCancel.Label = "gtk-cancel";
		this.AddActionWidget (this.buttonCancel, -6);
		global::Gtk.ButtonBox.ButtonBoxChild w8 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w7 [this.buttonCancel]));
		w8.Expand = false;
		w8.Fill = false;
		// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
		this.buttonOk = new global::Gtk.Button ();
		this.buttonOk.CanDefault = true;
		this.buttonOk.CanFocus = true;
		this.buttonOk.Name = "buttonOk";
		this.buttonOk.UseStock = true;
		this.buttonOk.UseUnderline = true;
		this.buttonOk.Label = "gtk-ok";
		this.AddActionWidget (this.buttonOk, -5);
		global::Gtk.ButtonBox.ButtonBoxChild w9 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w7 [this.buttonOk]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
	}
}
