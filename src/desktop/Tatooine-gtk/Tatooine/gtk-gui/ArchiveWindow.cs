
// This file has been generated by the GUI designer. Do not modify.

public partial class ArchiveWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.HBox hbox2;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView groupsView;
	private global::Gtk.VBox vbox2;
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	private global::Gtk.TreeView entriesView;
	private global::Gtk.Statusbar statusbar3;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget ArchiveWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "ArchiveWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("ArchiveWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child ArchiveWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'/></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.WidthRequest = 10;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.groupsView = new global::Gtk.TreeView ();
		this.groupsView.CanFocus = true;
		this.groupsView.Name = "groupsView";
		this.GtkScrolledWindow.Add (this.groupsView);
		this.hbox2.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.GtkScrolledWindow]));
		w4.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.entriesView = new global::Gtk.TreeView ();
		this.entriesView.CanFocus = true;
		this.entriesView.Name = "entriesView";
		this.GtkScrolledWindow1.Add (this.entriesView);
		this.vbox2.Add (this.GtkScrolledWindow1);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow1]));
		w6.Position = 0;
		this.hbox2.Add (this.vbox2);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vbox2]));
		w7.Position = 1;
		this.vbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox2]));
		w8.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar3 = new global::Gtk.Statusbar ();
		this.statusbar3.Name = "statusbar3";
		this.statusbar3.Spacing = 6;
		this.vbox1.Add (this.statusbar3);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar3]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 680;
		this.DefaultHeight = 443;
		this.Show ();
		this.groupsView.CursorChanged += new global::System.EventHandler (this.groupItemSelected);
	}
}
