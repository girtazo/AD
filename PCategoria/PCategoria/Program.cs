using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;

namespace PCategoria
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			Application.Quit ();
		}
	}
}
