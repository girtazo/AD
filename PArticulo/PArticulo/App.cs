using System;
using System.Data;
using MySql.Data.MySqlClient;
using PArticulo;

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
		set { servidor = value; }
	}
	private string usuario = "root";
	public string Usuario {
		get { return usuario;}
		set { usuario = value; }
	}
	private string password = "sistemas";
	public string Password {
		get { return password;}
		set { password = value; }
	}
	private string BaseDatos = "dbprueba";
	public string baseDatos {
		get { return BaseDatos;}
		set { BaseDatos = value; }
	}
	private IDbConnection mysqlConnection ;
	public IDbConnection MysqlConnection {
		get { 
			if (mysqlConnection == null)
				mysqlConnection = new MySqlConnection("Database="+BaseDatos+";Data Source="+servidor+";User Id="+usuario+";Password="+password);
			return mysqlConnection;
		}
		set { mysqlConnection = value; }
	}
}

