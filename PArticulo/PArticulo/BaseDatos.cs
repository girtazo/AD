using Gtk;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace PArticulo
{
	public partial class BaseDatos : Gtk.Window
	{
		private ListStore campos;
		private List<Tabla> tabla = new List<Tabla> ();
		private int tablasAbiertas = 0;
		public BaseDatos () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		public void construirTabla(string nombre){
			tabla [tablasAbiertas] = new Tabla (nombre);
			tabla [tablasAbiertas].listar ();
			tablasAbiertas = tablasAbiertas +1;
		}
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}

}

