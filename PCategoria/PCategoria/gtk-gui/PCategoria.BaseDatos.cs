
// This file has been generated by the GUI designer. Do not modify.
namespace PCategoria
{
	public partial class BaseDatos
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action refreshAction;
		private global::Gtk.Action addAction;
		private global::Gtk.Action deleteAction;
		private global::Gtk.Action saveAction;
		private global::Gtk.Action floppyAction;
		private global::Gtk.VBox vbox3;
		private global::Gtk.MenuBar menubar2;
		private global::Gtk.Toolbar toolbar2;
		private global::Gtk.Notebook notebook3;
		private global::Gtk.Label label3;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PCategoria.BaseDatos
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
			w1.Add (this.refreshAction, null);
			this.addAction = new global::Gtk.Action ("addAction", null, null, "gtk-add");
			w1.Add (this.addAction, null);
			this.deleteAction = new global::Gtk.Action ("deleteAction", null, null, "gtk-delete");
			w1.Add (this.deleteAction, null);
			this.saveAction = new global::Gtk.Action ("saveAction", null, null, "gtk-save");
			w1.Add (this.saveAction, null);
			this.floppyAction = new global::Gtk.Action ("floppyAction", null, null, "gtk-floppy");
			w1.Add (this.floppyAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "PCategoria.BaseDatos";
			this.Title = global::Mono.Unix.Catalog.GetString ("BaseDatos");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PCategoria.BaseDatos.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar2'/></ui>");
			this.menubar2 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar2")));
			this.menubar2.Name = "menubar2";
			this.vbox3.Add (this.menubar2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.menubar2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar2'><toolitem name='refreshAction' action='refreshAction'/><toolitem name='addAction' action='addAction'/><toolitem name='deleteAction' action='deleteAction'/><toolitem name='saveAction' action='saveAction'/><toolitem name='floppyAction' action='floppyAction'/></toolbar></ui>");
			this.toolbar2 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar2")));
			this.toolbar2.Name = "toolbar2";
			this.toolbar2.ShowArrow = false;
			this.vbox3.Add (this.toolbar2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.toolbar2]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.notebook3 = new global::Gtk.Notebook ();
			this.notebook3.CanFocus = true;
			this.notebook3.Name = "notebook3";
			this.notebook3.CurrentPage = 0;
			// Notebook tab
			global::Gtk.Label w4 = new global::Gtk.Label ();
			w4.Visible = true;
			this.notebook3.Add (w4);
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.notebook3.SetTabLabel (w4, this.label3);
			this.label3.ShowAll ();
			this.vbox3.Add (this.notebook3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.notebook3]));
			w5.Position = 2;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
