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
		private NotebookTabla contenedor;
		private MainWindow login;
		private bool autoguardado;

		public BaseDatos (MainWindow login) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.login = login;
			this.tabla = new List<Tabla>();
			this.tablasAbiertas = 0;
			this.contenedor = new NotebookTabla ();
			this.autoguardado = true;
			vbox1.Add (contenedor);
			this.ConstruirTabla ("articulo");
			this.ConstruirTabla ("categoria");
		}
		public void ConstruirTabla(string nombre){

			this.tabla.Add( new Tabla (this.contenedor,nombre));
			this.tablasAbiertas = tablasAbiertas + 1;
		}
		protected void OnDeleteEvent (object sender,DeleteEventArgs a){
			this.Destroy ();
			a.RetVal = true;
			this.login.ShowAll();
		}
		protected void TablaArticulo (object sender, EventArgs e)
		{
			this.ConstruirTabla ("Articulo");
		}
		protected void TablaCategoria (object sender, EventArgs e)
		{
			this.ConstruirTabla ("Categoria");
		}
	}
}