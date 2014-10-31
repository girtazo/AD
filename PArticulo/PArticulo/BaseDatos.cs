using System;
using Gtk;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace PArticulo
{
	public partial class BaseDatos : Gtk.Window
	{
		private List<TreeViewTabla> treeView = new List<TreeViewTabla> ();
		private List<Tabla> tabla = new List<Tabla>();
		private NotebookTabla recuadro = new NotebookTabla();
		private int tablasAbiertas = 0;
		public BaseDatos () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		public void ConstruirTabla(string nombre){

			this.tabla.Add( new Tabla (nombre));
			this.treeView.Add(new TreeViewTabla(this.tabla [tablasAbiertas].getCampos ()));
			recuadro.PestanyaNueva (this.treeView[tablasAbiertas],this.tabla[tablasAbiertas].nombre);
			this.tablasAbiertas = tablasAbiertas + 1;
		}
	}
}