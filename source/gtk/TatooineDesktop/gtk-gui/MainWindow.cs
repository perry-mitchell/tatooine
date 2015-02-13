
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	private global::Gtk.Label label2;
	private global::Gtk.Frame frame1;
	private global::Gtk.Alignment GtkAlignment;
	private global::Gtk.VBox vbox2;
	private global::Gtk.VBox vbox3;
	private global::Gtk.HBox hbox3;
	private global::Gtk.Label label3;
	private global::Gtk.Entry archiveFilePathLabel;
	private global::Gtk.HBox hbox4;
	private global::Gtk.Label label4;
	private global::Gtk.Entry archivePasswordLabel;
	private global::Gtk.HSeparator hseparator1;
	private global::Gtk.HBox hbox6;
	private global::Gtk.Label label5;
	private global::Gtk.Entry entry3;
	private global::Gtk.HSeparator hseparator2;
	private global::Gtk.VBox vbox6;
	private global::Gtk.Label label6;
	private global::Gtk.HBox hbox7;
	private global::Gtk.Button button4;
	private global::Gtk.Label GtkLabel1;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Button button1;
	private global::Gtk.Button button2;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.WidthRequest = 450;
		this.HeightRequest = 300;
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.Resizable = false;
		this.AllowGrow = false;
		this.DefaultWidth = 450;
		this.DefaultHeight = 300;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Select your password archive and enter your master password (and key file, if applicable) to login.");
		this.label2.Wrap = true;
		this.vbox1.Add (this.label2);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.label2]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.label3 = new global::Gtk.Label ();
		this.label3.WidthRequest = 130;
		this.label3.Name = "label3";
		this.label3.Xalign = 0F;
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Archive File:");
		this.hbox3.Add (this.label3);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label3]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.archiveFilePathLabel = new global::Gtk.Entry ();
		this.archiveFilePathLabel.CanFocus = true;
		this.archiveFilePathLabel.Name = "archiveFilePathLabel";
		this.archiveFilePathLabel.IsEditable = true;
		this.archiveFilePathLabel.InvisibleChar = '•';
		this.hbox3.Add (this.archiveFilePathLabel);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.archiveFilePathLabel]));
		w3.Position = 1;
		this.vbox3.Add (this.hbox3);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.label4 = new global::Gtk.Label ();
		this.label4.WidthRequest = 130;
		this.label4.Name = "label4";
		this.label4.Xalign = 0F;
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Master Password:");
		this.hbox4.Add (this.label4);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label4]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbox4.Gtk.Box+BoxChild
		this.archivePasswordLabel = new global::Gtk.Entry ();
		this.archivePasswordLabel.CanFocus = true;
		this.archivePasswordLabel.Name = "archivePasswordLabel";
		this.archivePasswordLabel.IsEditable = true;
		this.archivePasswordLabel.Visibility = false;
		this.archivePasswordLabel.InvisibleChar = '•';
		this.hbox4.Add (this.archivePasswordLabel);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.archivePasswordLabel]));
		w6.Position = 1;
		this.vbox3.Add (this.hbox4);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
		w7.Position = 1;
		w7.Expand = false;
		w7.Fill = false;
		this.vbox2.Add (this.vbox3);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox3]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hseparator1 = new global::Gtk.HSeparator ();
		this.hseparator1.Name = "hseparator1";
		this.vbox2.Add (this.hseparator1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator1]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox6 = new global::Gtk.HBox ();
		this.hbox6.Name = "hbox6";
		this.hbox6.Spacing = 6;
		// Container child hbox6.Gtk.Box+BoxChild
		this.label5 = new global::Gtk.Label ();
		this.label5.WidthRequest = 130;
		this.label5.Name = "label5";
		this.label5.Xalign = 0F;
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Key File:");
		this.hbox6.Add (this.label5);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label5]));
		w10.Position = 0;
		w10.Expand = false;
		w10.Fill = false;
		// Container child hbox6.Gtk.Box+BoxChild
		this.entry3 = new global::Gtk.Entry ();
		this.entry3.CanFocus = true;
		this.entry3.Name = "entry3";
		this.entry3.IsEditable = true;
		this.entry3.InvisibleChar = '•';
		this.hbox6.Add (this.entry3);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.entry3]));
		w11.Position = 1;
		this.vbox2.Add (this.hbox6);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox6]));
		w12.Position = 2;
		w12.Expand = false;
		w12.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hseparator2 = new global::Gtk.HSeparator ();
		this.hseparator2.Name = "hseparator2";
		this.vbox2.Add (this.hseparator2);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator2]));
		w13.Position = 3;
		w13.Expand = false;
		w13.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.vbox6 = new global::Gtk.VBox ();
		this.vbox6.Name = "vbox6";
		this.vbox6.Spacing = 6;
		// Container child vbox6.Gtk.Box+BoxChild
		this.label6 = new global::Gtk.Label ();
		this.label6.Name = "label6";
		this.label6.Xalign = 0F;
		this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Start new archive");
		this.vbox6.Add (this.label6);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox6 [this.label6]));
		w14.Position = 0;
		w14.Expand = false;
		w14.Fill = false;
		this.vbox2.Add (this.vbox6);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.vbox6]));
		w15.Position = 4;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox7 = new global::Gtk.HBox ();
		this.hbox7.Name = "hbox7";
		this.hbox7.Spacing = 6;
		// Container child hbox7.Gtk.Box+BoxChild
		this.button4 = new global::Gtk.Button ();
		this.button4.WidthRequest = 80;
		this.button4.HeightRequest = 30;
		this.button4.CanFocus = true;
		this.button4.Name = "button4";
		this.button4.UseUnderline = true;
		this.button4.Label = global::Mono.Unix.Catalog.GetString ("Create");
		this.hbox7.Add (this.button4);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.button4]));
		w16.PackType = ((global::Gtk.PackType)(1));
		w16.Position = 1;
		w16.Expand = false;
		w16.Fill = false;
		this.vbox2.Add (this.hbox7);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox7]));
		w17.Position = 5;
		w17.Expand = false;
		w17.Fill = false;
		this.GtkAlignment.Add (this.vbox2);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel1 = new global::Gtk.Label ();
		this.GtkLabel1.Name = "GtkLabel1";
		this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Archive Details</b>");
		this.GtkLabel1.UseMarkup = true;
		this.frame1.LabelWidget = this.GtkLabel1;
		this.vbox1.Add (this.frame1);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame1]));
		w20.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.WidthRequest = 90;
		this.button1.HeightRequest = 30;
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("Close");
		this.hbox1.Add (this.button1);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button1]));
		w21.PackType = ((global::Gtk.PackType)(1));
		w21.Position = 1;
		w21.Expand = false;
		w21.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button2 = new global::Gtk.Button ();
		this.button2.WidthRequest = 120;
		this.button2.HeightRequest = 30;
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString ("Open Archive");
		this.hbox1.Add (this.button2);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button2]));
		w22.PackType = ((global::Gtk.PackType)(1));
		w22.Position = 2;
		w22.Expand = false;
		w22.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w23.Position = 2;
		w23.Expand = false;
		w23.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.button2.Clicked += new global::System.EventHandler (this.openArchiveClicked);
		this.button1.Clicked += new global::System.EventHandler (this.closeButtonClicked);
	}
}
