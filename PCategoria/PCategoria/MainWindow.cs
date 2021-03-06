using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;

namespace PCategoria
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

			} catch (MySqlException e) {
				Console.WriteLine("Usuario:"+App.Instance.Usuario+"Password: "+App.Instance.Password );
				MessageDialog error = new MessageDialog (
					this,DialogFlags.Modal,
					MessageType.Error,
					ButtonsType.Close,
					e.Message
				);
				error.Title = "Imposible Conexion";
				Console.WriteLine (ResponseType.Close);
				error.Run ();
				if ( ResponseType.Close.ToString() == "Close" ) {
					Console.WriteLine ();
					error.Destroy ();
				}
			}
			MySQL ventanaMysql = new MySQL();

			/*ventanaMysql.listarBaseDatos ();

			ventanaMysql.Show ();*/
			/*ventanaMysql.mostrarTablas ();*/
		}
		protected void conecta (object sender, EventArgs e)
		{
			Console.WriteLine (entryUsuario.Text+entryPassword.Text);

			App.Instance.Usuario = entryUsuario.Text;
			App.Instance.Password = entryPassword.Text;

			obtenerConexion ();
		}
	}
}

