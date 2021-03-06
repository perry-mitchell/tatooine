
// This file has been generated by the GUI designer. Do not modify.
namespace TatooineDesktop
{
	public partial class ArchiveWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action ArchiveAction;
		private global::Gtk.Action GroupAction;
		private global::Gtk.Action EntryAction;
		private global::Gtk.Action CreateNewGroupAction;
		private global::Gtk.Action saveAction;
		private global::Gtk.Action CreateNewEntryAction;
		private global::Gtk.Action addAction;
		private global::Gtk.Action editAction;
		private global::Gtk.Action deleteAction;
		private global::Gtk.Action saveAsAction;
		private global::Gtk.Action homeAction;
		private global::Gtk.Action disconnectAction;
		private global::Gtk.VBox vbox4;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.HBox hbox5;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView groupTree;
		private global::Gtk.VBox vbox5;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TreeView entriesTree;
		private global::Gtk.VBox vbox2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow2;
		private global::Gtk.TreeView entryPropertiesTree;
		private global::Gtk.Toolbar toolbar1;
		private global::Gtk.Statusbar statusbar1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget TatooineDesktop.ArchiveWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.ArchiveAction = new global::Gtk.Action ("ArchiveAction", global::Mono.Unix.Catalog.GetString ("Archive"), null, null);
			this.ArchiveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Archive");
			w1.Add (this.ArchiveAction, null);
			this.GroupAction = new global::Gtk.Action ("GroupAction", global::Mono.Unix.Catalog.GetString ("Group"), null, null);
			this.GroupAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Group");
			w1.Add (this.GroupAction, null);
			this.EntryAction = new global::Gtk.Action ("EntryAction", global::Mono.Unix.Catalog.GetString ("Entry"), null, null);
			this.EntryAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Entry");
			w1.Add (this.EntryAction, null);
			this.CreateNewGroupAction = new global::Gtk.Action ("CreateNewGroupAction", global::Mono.Unix.Catalog.GetString ("Create New Group"), null, null);
			this.CreateNewGroupAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Create New Group");
			w1.Add (this.CreateNewGroupAction, null);
			this.saveAction = new global::Gtk.Action ("saveAction", global::Mono.Unix.Catalog.GetString ("Save"), null, "gtk-save");
			this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save");
			w1.Add (this.saveAction, null);
			this.CreateNewEntryAction = new global::Gtk.Action ("CreateNewEntryAction", global::Mono.Unix.Catalog.GetString ("Create New Entry"), null, null);
			this.CreateNewEntryAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Create New Entry");
			w1.Add (this.CreateNewEntryAction, null);
			this.addAction = new global::Gtk.Action ("addAction", null, null, "gtk-add");
			w1.Add (this.addAction, null);
			this.editAction = new global::Gtk.Action ("editAction", null, null, "gtk-edit");
			w1.Add (this.editAction, null);
			this.deleteAction = new global::Gtk.Action ("deleteAction", null, null, "gtk-delete");
			w1.Add (this.deleteAction, null);
			this.saveAsAction = new global::Gtk.Action ("saveAsAction", global::Mono.Unix.Catalog.GetString ("Save As"), null, "gtk-save-as");
			this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save As");
			w1.Add (this.saveAsAction, null);
			this.homeAction = new global::Gtk.Action ("homeAction", global::Mono.Unix.Catalog.GetString ("Log Out"), null, "gtk-home");
			this.homeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Log Out");
			w1.Add (this.homeAction, null);
			this.disconnectAction = new global::Gtk.Action ("disconnectAction", global::Mono.Unix.Catalog.GetString ("Exit"), null, "gtk-disconnect");
			this.disconnectAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
			w1.Add (this.disconnectAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.WidthRequest = 640;
			this.HeightRequest = 480;
			this.Name = "TatooineDesktop.ArchiveWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("ArchiveWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TatooineDesktop.ArchiveWindow.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox ();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='ArchiveAction' action='ArchiveAction'><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='homeAction' action='homeAction'/><menuitem name='disconnectAction' action='disconnectAction'/></menu><menu name='GroupAction' action='GroupAction'><menuitem name='CreateNewGroupAction' action='CreateNewGroupAction'/></menu><menu name='EntryAction' action='EntryAction'><menuitem name='CreateNewEntryAction' action='CreateNewEntryAction'/></menu></menubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vbox4.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.groupTree = new global::Gtk.TreeView ();
			this.groupTree.CanFocus = true;
			this.groupTree.Name = "groupTree";
			this.GtkScrolledWindow.Add (this.groupTree);
			this.hbox5.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.GtkScrolledWindow]));
			w4.Position = 0;
			// Container child hbox5.Gtk.Box+BoxChild
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.entriesTree = new global::Gtk.TreeView ();
			this.entriesTree.CanFocus = true;
			this.entriesTree.Name = "entriesTree";
			this.GtkScrolledWindow1.Add (this.entriesTree);
			this.vbox5.Add (this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.GtkScrolledWindow1]));
			w6.Position = 0;
			// Container child vbox5.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.entryPropertiesTree = new global::Gtk.TreeView ();
			this.entryPropertiesTree.CanFocus = true;
			this.entryPropertiesTree.Name = "entryPropertiesTree";
			this.GtkScrolledWindow2.Add (this.entryPropertiesTree);
			this.vbox2.Add (this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow2]));
			w8.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='addAction' action='addAction'/><toolitem name='editAction' action='editAction'/><toolitem name='deleteAction' action='deleteAction'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.vbox2.Add (this.toolbar1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.toolbar1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox5.Add (this.vbox2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this.vbox2]));
			w10.Position = 1;
			this.hbox5.Add (this.vbox5);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.vbox5]));
			w11.Position = 1;
			this.vbox4.Add (this.hbox5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.hbox5]));
			w12.Position = 1;
			// Container child vbox4.Gtk.Box+BoxChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			this.vbox4.Add (this.statusbar1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox4 [this.statusbar1]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			this.Add (this.vbox4);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 640;
			this.DefaultHeight = 480;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.windowClose);
			this.CreateNewGroupAction.Activated += new global::System.EventHandler (this.createNewGroupActivated);
			this.saveAction.Activated += new global::System.EventHandler (this.saveArchiveActivated);
			this.CreateNewEntryAction.Activated += new global::System.EventHandler (this.createNewEntryActivated);
			this.saveAsAction.Activated += new global::System.EventHandler (this.saveAsButtonActivated);
			this.disconnectAction.Activated += new global::System.EventHandler (this.exitButtonActivated);
			this.groupTree.CursorChanged += new global::System.EventHandler (this.groupRowSelected);
			this.groupTree.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.groupListButtonPress);
			this.entriesTree.CursorChanged += new global::System.EventHandler (this.entryRowSelected);
			this.entriesTree.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.entriesListButtonPress);
			this.entryPropertiesTree.RowActivated += new global::Gtk.RowActivatedHandler (this.entryPropertyRowActivated);
		}
	}
}
