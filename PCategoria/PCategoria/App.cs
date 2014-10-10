using System;
using System.Data;
using MySql.Data.MySqlClient;
using PCategoria;

public class App
{
	private App ()
	{

	}
	private static App instance = new App();
	public static App Instance {
		get { return instance; }
	}
	private MySqlConnection mysqlConnection;
	public MySqlConnection MysqlConnection {
		get { return mysqlConnection;}
		set { mysqlConnection = value; }
	}
}
