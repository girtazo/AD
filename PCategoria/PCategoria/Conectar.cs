using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;

namespace PCategoria
{
	public partial class Conectar: Gtk.Window
	{
		private static MySqlConnection conexion;
		private static string Usuario = "root";
		private static string Password = "sistemas";
		private static string ubicacion = "localhost";
		public Conectar () : base(Gtk.WindowType.Toplevel)
		{
			Build ();
		}
		private void obtenerConexion() {
			try {

				conexion = new MySqlConnection ("Data Source="+ubicacion+";User Id="+Usuario+";Password="+Password);
				conexion.Open ();
			} catch (MySqlException e) {
				Console.WriteLine("Usuario:"+Usuario+"Password: "+Password );
				MessageDialog error = new MessageDialog (
					this,DialogFlags.Modal,
					MessageType.Error,
					ButtonsType.Close,
					"La conexion con la base de datos ha sido imposible, comprueba que el usuario y contyraseña son los correctos"
				);
				error.Title = "Imposible Conexion";
				error.Run();
			}
		}
		private void listar() {
			MySqlCommand sentenciaSQL = new MySqlCommand ("sp_databases");
			MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
		}
		protected void conecta (object sender, EventArgs e)
		{
			Usuario = entryUsuario.Text;
			Password = entryPassword.Text;
			obtenerConexion ();
		}
	}
}

