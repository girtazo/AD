using System;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;
using MySql;
namespace PCategoria
{
	public class Tabla
	{
		private IDataReader Lector;
		private string [] campos;
		private object [] valores;
		private string nombre;
		public Tabla(string nombre){
			IDbCommand sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
			sentenciaSQL.CommandText = "Select * from " + this.nombre;
			Lector = sentenciaSQL.ExecuteReader ();
		}
		public string [] getCampos(bool close = 0)
		{
			this.campos = new string[Lector.FieldCount];
			for (int campo=0; campo < campos; campo++) {
				this.campos[campo] = Lector.GetName (campo);
			}
			if (close) {
				Lector.Close ();
			}
			return campos;
		}
		public string [] listar(bool close = 0)
		{
			int c = 0;
			while (Lector.Read ()) {
				for (int campo=0; campo < this.campos.Length; campo++) {
					valores[c][this.campos[campo]] = Lector[this.campos[campo]];
				}
				c = c + 1;
			}
			if (close) {
				Lector.Close ();
			}
			return valores;
		}
	}
}

