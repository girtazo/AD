using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace PArticulo
{
	public class BDTabla
	{
		private IDataReader Lector;
		private IDbCommand sentenciaSQL;
		private List<Campo> campos;
		private List<Object> valores;
		public string nombre;
		public BDTabla(string nombre){
			this.nombre = nombre;
			this.sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
			this.campos = new List<Campo>();
			this.sentenciaSQL.CommandText = "Select * FROM "+this.nombre+" LIMIT 1";
			Lector = this.sentenciaSQL.ExecuteReader ();
			for (int campo=0; campo < this.Lector.FieldCount; campo++) {
				this.campos.Add( new Campo (this.Lector.GetName (campo), this.Lector.GetFieldType (campo)));
			}
			Lector.Close ();
		}
		public List<Campo> getCampos()
		{
			return this.campos;
		}
		public List<Object> listar()
		{
			this.valores = new List<object>();
			this.sentenciaSQL.CommandText = "Select * FROM "+this.nombre;
			Lector = this.sentenciaSQL.ExecuteReader ();
			switch (this.nombre) {
			case "categoria":
				while (Lector.Read ()) {
					this.valores.Add (new Categoria (Convert.ToUInt64 (Lector ["id"]), Lector ["nombre"].ToString ()));
				}
				break;
			case "articulo":
				while (Lector.Read ()) {
					this.valores.Add ( new Articulo ( 
					    	                        Convert.ToUInt64( Lector ["id"]),
					        	                    Lector ["nombre"].ToString(),
					            	      			Lector ["categoria"],
					                	            Lector ["precio"]
					                    	        )
					                  );
				}
				break;
			}
			return this.valores;
		}
	}
}


