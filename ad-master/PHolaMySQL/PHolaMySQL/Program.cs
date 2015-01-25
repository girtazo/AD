using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PHolaMySQL
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Contraseña para usuario root: " );
			string password = Console.ReadLine ();

			string connectionString =
				"Server=localhost;" + "Database=dbprueba;" +
				"User ID=root;" + "Password=" + password;
			MySqlConnection mySqlConnection = new MySqlConnection (connectionString);

			mySqlConnection.Open ();

			string respuesta = "5";

			while (respuesta != "0")
			{
				Console.Clear ();
				Console.WriteLine ("1.Nuevo\n2.Modificar\n3.Eliminar\n4.Ver\n\n0.Salir\n");
				respuesta = Console.ReadLine ();

				switch (respuesta)
				{
					//Salir
				case "0":{ Console.WriteLine ("\nSaliendo..."); break;}
					//Nuevo
				case "1":{ Console.Clear (); mysqlNuevo (mySqlConnection); break;}
					//Modificar
				case "2":{ Console.Clear (); mysqlModificar (mySqlConnection); break;}
					//Eliminar
				case "3":{ Console.Clear (); mysqlEliminar (mySqlConnection); break;}
					//Ver
				case "4":{ Console.Clear (); mysqlVer (mySqlConnection); break;}
					//Default
				default:{ Console.Clear (); Console.WriteLine ("\nError 404 Not Found"); respuesta = "0"; break;}

				}

			}

			Console.Write ("");

			mySqlConnection.Close ();

		}

		public static void mysqlNuevo (MySqlConnection mySqlConnection)
		{
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = 
				string.Format ("");

			mySqlCommand.ExecuteNonQuery ();

		}

		public static void mysqlModificar (MySqlConnection mySqlConnection)
		{
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = 
				string.Format ("INSERT INTO categoria (nombre) VALUES ('{0}')", DateTime.Now);

			mySqlCommand.ExecuteNonQuery ();

		}

		public static void mysqlEliminar (MySqlConnection mySqlConnection)
		{
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = 
				string.Format ("");

			mySqlCommand.ExecuteNonQuery ();

		}

		public static void mysqlVer (MySqlConnection mySqlConnection)
		{
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "SELECT * FROM categoria";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			Console.WriteLine ("FieldCount = {0}", mySqlDataReader.FieldCount);
			for (int index = 0; index < mySqlDataReader.FieldCount; index++)
			{
				Console.WriteLine ("Column {0} = {1}", index, mySqlDataReader.GetName (index));

			}

			while (mySqlDataReader.Read()) 
			{
				object id = mySqlDataReader ["id"];
				object nombre = mySqlDataReader ["nombre"];

				Console.Write ("\n{0}, {1}", id, nombre);

			}

			Console.WriteLine ("\n\nPress any key to continue...");
			Console.Read ();

			mySqlDataReader.Close ();

		}

	}
}
