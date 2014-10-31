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
		}
		private void obtenerConexion() {
			try {
				App.Instance.MysqlConnection.Open();
				BaseDatos baseDatos = new BaseDatos();
				baseDatos.ConstruirTabla("categoria");
				baseDatos.ShowAll();
				this.Destroy();
			} catch (MySqlException e) {
				Console.WriteLine("Usuario:"+App.Instance.Usuario+"Password: "+App.Instance.Password );
				MessageDialog error = new MessageDialog (
					this,
					DialogFlags.Modal,
					MessageType.Error,
					ButtonsType.Close,
					e.Message
					);
				error.Title = "Imposible Conexion";
				Console.WriteLine (ResponseType.Close);
				error.Run ();
				Console.ReadLine ();
				if ( ResponseType.Close.ToString() == "Close" ) {
					Console.WriteLine ();
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
