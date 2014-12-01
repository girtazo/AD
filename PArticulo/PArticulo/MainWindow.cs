using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;
namespace PArticulo
{
	public partial class MainWindow: Gtk.Window
	{
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			this.entryUsuario.Text = "root";
			this.entryPassword.Text = "sistemas";
			Focus = this.GtkButton;
		}
		private void obtenerConexion() {
			try {
				App.Instance.MysqlConnection.Open();
				BaseDatos baseDatos = new BaseDatos(this);
				baseDatos.ShowAll();
				this.HideAll();
			} catch (MySqlException e) {
				App.Instance.MysqlConnection.Close ();
				MessageDialog error = new MessageDialog (
					this,
					DialogFlags.Modal,
					MessageType.Error,
					ButtonsType.Close,
					e.Message
					);
				error.Title = "Imposible Conexion";
				error.Run ();
				if ( ResponseType.Close.ToString() == "Close" ) {
					error.Destroy ();
				}
			}
		}
		protected void conecta (object sender, EventArgs e)
		{
			App.Instance.Usuario = entryUsuario.Text;
			App.Instance.Password = entryPassword.Text;
			obtenerConexion ();
		}
		protected void OnDeleteEvent (object sender,DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;
		}
	}
}