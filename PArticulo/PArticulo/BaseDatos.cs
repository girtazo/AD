using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace PArticulo
{
	public partial class BaseDatos : Gtk.Window
	{
		private List<Tabla> tabla;
		private int tablasAbiertas;
		public BaseDatos () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.tabla = new List<Tabla>();
			this.tablasAbiertas = 0;
		}
		public void ConstruirTabla(string nombre){

			this.tabla.Add( new Tabla (nombre));
			vbox1.ShowAll ();
			vbox1.Add (this.tabla [tablasAbiertas].pestanya);
			this.tablasAbiertas = tablasAbiertas + 1;
			vbox1.ShowAll ();
		}
	}
}