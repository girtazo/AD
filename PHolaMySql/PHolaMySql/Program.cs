using System;
using MySql.Data.MySqlClient;

namespace PHolaMySql
{
	class MainClass
	{
		private static string usuario = "root";
		private static string password = "sistemas";
		private static string baseDatos = "dbprueba";
		private static string tabla = "categoria";
		private static MySqlConnection conexion;
		public static void Main (string[] args)
		{
			int opcion;
			opcion = 5;
			bool entrada = false;
			conexion = new MySqlConnection ("Database="+baseDatos+";Data Source=localhost;User Id="+usuario+";Password="+password);
			conexion.Open ();
			while (opcion != 0) {
				menu ();
				if (entrada) {
					Console.Write ("Introduce Opcion:");
				} else {
					Console.Write ("Vuelva intentarlo opcion:");
				}
				try {
					opcion = Convert.ToInt32( Console.ReadLine () );
					Console.Clear();
					entrada = true;
					switch(opcion) {
						case 1:
						conectar ();
						break;
						case 2:
						listar ();
						break;
						case 3:
						insertar ();
						break;
						case 4:
						modificar ();
						break;
						case 5:
						eliminar ();
						break;
					}
					if(opcion !=0){
						Console.WriteLine ("Pulsa cualquier tecla para volver a menu......");
						Console.ReadLine ();
					}
					Console.Clear ();
				} catch {
					entrada = false;
				}
			}
			conexion.Close();
		}
		public static void menu () {
			Console.Clear();
			Console.WriteLine ("Elige que opcion quieres hacer en la tabla categoria de la base de datos dbPrueba, introduciendo el numero correspondiente a la operación:");
			Console.WriteLine ("0 - Salir");
			Console.WriteLine ("1 - Conectar");
			Console.WriteLine ("2 - Listar");
			Console.WriteLine ("3 - Nuevo");
			Console.WriteLine ("4 - Modificar");
			Console.WriteLine ("5 - Eliminar");
		}
		public static void conectar () {
			bool entrada = false;
			while (entrada == false) {
				Console.Clear();
				try {
					Console.WriteLine ("Introduce el usuario de MySQL");
					usuario = Console.ReadLine ();
					Console.WriteLine ("Introduce el password de MySQL");
					password = Console.ReadLine ();
					conexion = new MySqlConnection ("Database="+baseDatos+";Data Source=localhost;User Id="+usuario+";Password="+password);
					conexion.Open ();
					entrada = true;
				} catch (MySqlException) {
					entrada = false;
					Console.WriteLine ("Conexion fallida!!! Revise su usuario y contraseña. Vuelva a intentarlo pulsando INTRO");
					Console.ReadLine ();
				}
			}
		}
		public static void listar() {
			int c;
			MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from categoria");
			sentenciaSQL.Connection = conexion;
			MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ("");
			while (Lector.Read()) {
				Console.WriteLine (String.Format("|Id:|{0, -15} | Nombre:{1, -15}|",Lector["id"],Lector["nombre"]));
			}
			Console.WriteLine ("");
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ();
			Lector.Close ();
		}
		public static void insertar(){
			bool entrada = false;
			int campo;
			int c;
			MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from "+tabla);
			sentenciaSQL.Connection = conexion;
			MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
			string [] valor = new string[Lector.FieldCount];
			object [] nombreCampo = new object[Lector.FieldCount];
			int campos = Lector.FieldCount;
			// Bucle de insercion de datos
			while (entrada == false) {
				Console.Clear ();
				// Bucle de peticion de valores de campos
				for (campo=1; campo < campos; campo++) {
					Console.WriteLine ("Introduce "+Lector.GetName(campo));
					nombreCampo[campo] = Lector.GetName (campo);
					valor[campo] = Console.ReadLine ();
				}
				Lector.Close ();

				// Construccion de la sentencia de insercion
				string insert = "INSERT INTO "+tabla+" (";
				for (campo=1; campo < campos-1; campo++) {
					insert += nombreCampo[campo]+", ";
				}
				insert += nombreCampo[campo]+") VALUES (";
				for (campo=1; campo < campos-1; campo++) {
					insert += "@"+nombreCampo[campo]+", ";
				}
				insert += "@"+nombreCampo[campo]+")";

				// Preparar la insercion
				sentenciaSQL = new MySqlCommand (insert);
				sentenciaSQL.Connection = conexion;
				sentenciaSQL.Prepare ();
				for (campo=1; campo < campos-1; campo++) {
					sentenciaSQL.Parameters.AddWithValue(nombreCampo[campo].ToString(),valor[campo]);
				}
				sentenciaSQL.Parameters.AddWithValue(nombreCampo[campo].ToString(),valor[campo]);
				try {
					Console.WriteLine(insert);
					sentenciaSQL.ExecuteNonQuery();
					sentenciaSQL = new MySqlCommand ("Select * from categoria");
					sentenciaSQL.Connection = conexion;
					Lector = sentenciaSQL.ExecuteReader ();
					for (c=0; c<35; c++) {
						Console.Write ("-");
					}
					Console.WriteLine ("");
					while (Lector.Read()) {
						Console.WriteLine (String.Format("|Id:|{0, -15} | Nombre:{1, -15}|",Lector["id"],Lector["nombre"]));
					}
					Console.WriteLine ("");
					for (c=0; c<35; c++) {
						Console.Write ("-");
					}
					Console.WriteLine ();
					Lector.Close ();
					entrada = true;
					Console.WriteLine("registro insertado");
				} catch(MySqlException){
					Console.WriteLine ("Insercion fallida!!! Revise que los datos sean correctos. Vuelva a intentarlo pulsando cualquier tecla");
					Console.ReadLine ();
					entrada = false;
				}
			}
		}
		public static void modificar(){
			int c;
			MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from "+tabla);
			sentenciaSQL.Connection = conexion;
			MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ("");
			while (Lector.Read()) {
				Console.WriteLine (String.Format("|Id:|{0, -15} | Nombre:{1, -15}|",Lector["id"],Lector["nombre"]));
			}
			Console.WriteLine ("");
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ();
			Lector.Close ();
			string update = "UPDATE categoria SET column1=value1,column2=value2,...\nWHERE some_column=some_value;";
			sentenciaSQL = new MySqlCommand (update);
			sentenciaSQL.Connection = conexion;
			sentenciaSQL.ExecuteNonQuery ();
		}
		public static void eliminar(){
			int c;
			int registro;
			MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from "+tabla);
			sentenciaSQL.Connection = conexion;
			MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ("");
			c = 0;
			while (Lector.Read()) {
				c++;
				Console.WriteLine (String.Format("Registro:{0,-10} |Id:|{1, -15} | Nombre:{2, -15}|",c,Lector["id"],Lector["nombre"]));
			}
			Console.WriteLine ("");
			for (c=0; c<35; c++) {
				Console.Write ("-");
			}
			Console.WriteLine ();
			Lector.Close ();
			Console.Write ("Elije el registro a borrar:");
			registro = Convert.ToInt32( Console.ReadLine () );
		}
	}
}
