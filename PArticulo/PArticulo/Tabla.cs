using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace PArticulo
{
	public class Tabla
	{
		private IDataReader Lector;
		private IDbCommand sentenciaSQL;
		private List<Campo> campos = new List<Campo>();
		private object [] valores;
		public string nombre;
		public Tabla(string nombre){
			this.nombre = nombre;
			this.sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
		}
		public List<Campo> getCampos()
		{
			this.sentenciaSQL.CommandText = "Select * from " + this.nombre;
			this.Lector = this.sentenciaSQL.ExecuteReader ();
			for (int campo=0; campo < this.Lector.FieldCount; campo++) {
				this.campos.Add( new Campo (this.Lector.GetName (campo), this.Lector.GetFieldType (campo)));
			}
			this.Lector.Close ();
			return this.campos;
		}
		public void listar()
		{
			int c = 0;
			while (Lector.Read ()) {
				Console.WriteLine (Lector ["id"].GetType());
				/*foreach(string campo in this.campos){
					valores[c][campo] = Lector[campo];
				}*/
				c = c + 1;
			}
		}
	}
}


