
// This file has been generated by the GUI designer. Do not modify.
namespace PCategoria
{
	public partial class MySQL
	{
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView treeViewBaseDatos;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PCategoria.MySQL
			this.Name = "PCategoria.MySQL";
			this.Title = global::Mono.Unix.Catalog.GetString ("MySQL");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PCategoria.MySQL.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeViewBaseDatos = new global::Gtk.TreeView ();
			this.treeViewBaseDatos.CanFocus = true;
			this.treeViewBaseDatos.Name = "treeViewBaseDatos";
			this.GtkScrolledWindow.Add (this.treeViewBaseDatos);
			this.Add (this.GtkScrolledWindow);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
		}
	}
}
