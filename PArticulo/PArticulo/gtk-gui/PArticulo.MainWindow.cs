
// This file has been generated by the GUI designer. Do not modify.
namespace PArticulo
{
	public partial class MainWindow
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry entryUsuario;
		private global::Gtk.Label label2;
		private global::Gtk.Entry entryPassword;
		private global::Gtk.Button GtkButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PArticulo.MainWindow
			this.Name = "PArticulo.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PArticulo.MainWindow.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Usuario");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryUsuario = new global::Gtk.Entry ();
			this.entryUsuario.CanFocus = true;
			this.entryUsuario.Name = "entryUsuario";
			this.entryUsuario.IsEditable = true;
			this.entryUsuario.InvisibleChar = '•';
			this.hbox1.Add (this.entryUsuario);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryUsuario]));
			w2.Position = 1;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Contraseña");
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryPassword = new global::Gtk.Entry ();
			this.entryPassword.CanFocus = true;
			this.entryPassword.Name = "entryPassword";
			this.entryPassword.IsEditable = true;
			this.entryPassword.InvisibleChar = '•';
			this.hbox1.Add (this.entryPassword);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryPassword]));
			w4.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.GtkButton = new global::Gtk.Button ();
			this.GtkButton.CanFocus = true;
			this.GtkButton.Name = "GtkButton";
			this.GtkButton.UseUnderline = true;
			this.GtkButton.Label = global::Mono.Unix.Catalog.GetString ("Conectar");
			this.hbox1.Add (this.GtkButton);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.GtkButton]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 555;
			this.DefaultHeight = 32;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.GtkButton.Clicked += new global::System.EventHandler (this.conecta);
		}
	}
}
