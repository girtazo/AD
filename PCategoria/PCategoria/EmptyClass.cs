using System;
using MySql.Data.MySqlClient;

namespace PCategoria
{
	public class Tabla
	{
		private Lector
		private campos;
		public Tabla(){
			IDbCommand sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
			sentenciaSQL.CommandText ("Select * from " + nombre);

		}
		public string [] campos()
		{

		}
	}
}

