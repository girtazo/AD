using MySql.Data.MySqlClient;
using System.Data;
using System;
using MySql.Data;
using System.Collections.Generic;
namespace PArticulo
{
	public class Tabla
	{
		private List<string> campos = new List<string> ();
		private List<object> valores = new List<object> ();
		private string nombre;
		private IDbCommand sentenciaSQL;
		public Tabla(string nombreTabla) {
			nombre = nombreTabla;
		}
		public List<string> getCampos()
		{
			sentenciaSQL.CommandText = "Select * from " + nombre;
			IDataReader Lector = sentenciaSQL.ExecuteReader ();
			for (int campo=0; campo < Lector.FieldCount; campo++) {
				campos[campo] = Lector.GetName (campo);
			}
			return campos;
		}
		public List<object> listar()
		{
			sentenciaSQL = App.Instance.MysqlConnection.CreateCommand();
			int c = 0;
			sentenciaSQL.CommandText = "Select * from " + nombre;
			IDataReader Lector = sentenciaSQL.ExecuteReader ();
			object [] tupla = new object[campos.Count];
			while (Lector.Read ()) {
				for(int campo = 0; campo < Lector.FieldCount;campo++ ) {
					tupla[c] = Lector.GetValue(campo);
				}
				valores [c] = tupla;
				c = c + 1;
			}

			return valores;
		}
	}
}

