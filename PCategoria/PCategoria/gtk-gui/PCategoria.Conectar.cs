
// This file has been generated by the GUI designer. Do not modify.
namespace PCategoria
{
	public partial class Conectar
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label labelUsuario;
		private global::Gtk.Entry entryUsuario;
		private global::Gtk.Label labelPassword;
		private global::Gtk.Entry entryPassword;
		private global::Gtk.Button bconecta;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget PCategoria.Conectar
			this.Name = "PCategoria.Conectar";
			this.Title = global::Mono.Unix.Catalog.GetString ("Window");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child PCategoria.Conectar.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelUsuario = new global::Gtk.Label ();
			this.labelUsuario.Name = "labelUsuario";
			this.labelUsuario.LabelProp = global::Mono.Unix.Catalog.GetString ("Usuario");
			this.hbox1.Add (this.labelUsuario);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.labelUsuario]));
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
			this.labelPassword = new global::Gtk.Label ();
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.LabelProp = global::Mono.Unix.Catalog.GetString ("Contraseña");
			this.hbox1.Add (this.labelPassword);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.labelPassword]));
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
			this.bconecta = new global::Gtk.Button ();
			this.bconecta.CanFocus = true;
			this.bconecta.Name = "bconecta";
			this.bconecta.UseUnderline = true;
			this.bconecta.Label = global::Mono.Unix.Catalog.GetString ("Conectar");
			this.hbox1.Add (this.bconecta);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.bconecta]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			this.Add (this.hbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 555;
			this.DefaultHeight = 29;
			this.Show ();
			this.bconecta.Clicked += new global::System.EventHandler (this.conecta);
		}
	}
}
