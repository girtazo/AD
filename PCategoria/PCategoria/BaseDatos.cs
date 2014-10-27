using Gtk;
using System.Data;
using System;
using MySql.Data.MySqlClient;
namespace PCategoria
{
	public partial class BaseDatos : Gtk.Window
	{
		private ListStore campos;
		private object[] tabla;
		public BaseDatos () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		private void construirTabla(string nombre){
			tabla[] [nombre] = new Tabla (nombre);
			tabla.AppendColumn (tabla[nombre], new CellRendererText (), "text", 0);
			tabla.AppendColumn ("nombre", new CellRendererText (), "text", 1);
			campos = new ListStore (typeof(string), typeof(string));
		}
	}
}

