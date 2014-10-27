using System;
using System.Data;
using Gtk;
//using MySql.Data.MySqlClient;
namespace PCategoria
{
	public partial class MySQL : Gtk.Window
	{
		private ListStore campos;
		public MySQL () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			// Base Datos
		}
		
		/*private void listarTablas() {
		}*/

		/*private void construirBaseDatos() {
			treeViewBaseDatos.AppendColumn ("DATABASE_NAME", new CellRendererText(), "sysname", 0);
			treeViewBaseDatos.AppendColumn ("DATABASE_SIZE", new CellRendererText (), "int", 1);
			treeViewBaseDatos.AppendColumn ("REMARKS", new CellRendererText (), "text", 2);
			campos = new ListStore (typeof(object), typeof(int),typeof(string));
			treeViewBaseDatos.Model = campos;
			Console.WriteLine ("construyendo tabla");
			Console.ReadLine ();

		}*/
		/*public void listarBaseDatos() {
			construirTabla ();
			Console.WriteLine ("listando");
			Console.ReadLine ();
			IDbCommand sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
			sentenciaSQL.CommandType = CommandType.StoredProcedure;
			sentenciaSQL.CommandText = "sp_databases";
			IDataReader Lector = sentenciaSQL.ExecuteReader ();
			while (Lector.Read()) {
				campos.AppendValues (Lector["DATABASE_NAME"], Lector["DATABASE_SIZE"], Lector["REMARKS"]);
			}
			Lector.Close ();
		}*/
	
	}
}

