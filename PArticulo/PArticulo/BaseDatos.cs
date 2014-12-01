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
		[MenuOpcion]
		public Gtk.Action opcionArticulo;
		[MenuOpcion]
		public Gtk.Action opcionCategoria;
		private bool autoguardado;
		public BaseDatos (MainWindow login = null) : base(Gtk.WindowType.Toplevel)
		{
			Build ();
			this.login = login;
			this.tabla = new List<Tabla>();
			this.tablasAbiertas = 0;
			this.opcionArticulo = ArticuloAction;
			this.opcionCategoria = CategoriaAction;
			this.contenedor = new NotebookTabla (this);
			this.autoguardado = true;
			vbox1.Add (contenedor);
			this.ConstruirTabla ("Articulo");
			this.ConstruirTabla ("Categoria");
		}
		public void ConstruirTabla(string nombre){
			this.tabla.Add( new Tabla (this.contenedor,nombre));
			this.tablasAbiertas = tablasAbiertas + 1;
		}
		protected void TablaArticulo (object sender, EventArgs e)
		{
			this.ConstruirTabla ("Articulo");
			this.ShowAll ();
		}
		public void setSensitiveArticulo(bool sensitive){
		}
		protected void TablaCategoria (object sender, EventArgs e)
		{
			this.ConstruirTabla ("Categoria");
			this.ShowAll ();
		}
		protected void OnDeleteEvent (object sender,DeleteEventArgs a){
			this.HideAll ();
			a.RetVal = true;
			this.login.ShowAll();
		}
	}
}