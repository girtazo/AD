using System;
using System.Data;
using MySql.Data.MySqlClient;
namespace PArticulo
{
	public class App
	{
		private App ()
		{
		}
		private static App instance = new App();
		public static App Instance {
			get { return instance; }
		}
		private string servidor = "localhost";
		public string Servidor {
			get { return servidor;}
			set {
				servidor = value;
				mysqlConnection = new MySqlConnection ("Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + password + ";DataBase=" + baseDatos);
			}
		}
		private string usuario = "root";
		public string Usuario {
			get { return usuario;}
			set {
				usuario = value;
				mysqlConnection = new MySqlConnection ("Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + password + ";DataBase=" + baseDatos);
			}
		}
		private string password = "sistemas";
		public string Password {
			get { return password;}
			set {
				password = value;
				mysqlConnection = new MySqlConnection ("Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + password + ";DataBase=" + baseDatos);
			}
		}
		private string baseDatos = "dbprueba";
		public string BaseDatos {
			get { return baseDatos;}
			set {
				baseDatos = value;
				mysqlConnection = new MySqlConnection ("Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + password + ";DataBase=" + baseDatos);
			}
		}
		private IDbConnection mysqlConnection;
		public IDbConnection MysqlConnection {
			get {
				if (mysqlConnection == null){
					mysqlConnection = new MySqlConnection ("Data Source=" + servidor + ";User Id=" + usuario + ";Password=" + password + ";DataBase=" + baseDatos);
				}
				return mysqlConnection;
			}
			set { mysqlConnection = value; }
		}
	}
}