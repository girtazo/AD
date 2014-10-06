using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;

public partial class MainWindow: Gtk.Window
{
	protected MySqlConnection conexion;
	private ListStore campos;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		obtenerConexion ();
		construirTabla ();
		rellenarTabla ();
	}
	public void rellenarTabla() {
		MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from categoria");
		sentenciaSQL.Connection = conexion;
		MySqlDataReader Lector = sentenciaSQL.ExecuteReader ();
		while (Lector.Read()) {
			
			campos.AppendValues (Lector["id"].ToString(), Lector["nombre"]);
		}
		Lector.Close ();
	}
	public void construirTabla() {
		tabla.AppendColumn ("id", new CellRendererText (), "text", 0);
		tabla.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		campos = new ListStore (typeof(string), typeof(string));
		tabla.Model = campos;//en java treeView.setModel(listStore)
		tabla.Selection.Changed += seleccionar;
	}
	void seleccionar (object sender, EventArgs e)
	{
		deleteAction.Sensitive = true;
		deleteAction.Sensitive = tabla.Selection.CountSelectedRows() > 0;
	}
	public void obtenerConexion () {
		conexion = new MySqlConnection ("Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas");
		conexion.Open ();
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void insertar (object sender, EventArgs e)
	{

	}
	protected void OnTablaSelectCursorRow (object o, SelectCursorRowArgs args)
	{
		campos.AppendValues("Ha sido seleccionado","j");
	}
	protected void borrar (object sender, EventArgs e)
	{
		TreeIter buscador;
		tabla.Selection.GetSelected (out buscador);
		object id = campos.GetValue (buscador,0);
		object nombre = campos.GetValue (buscador,1);

		Console.WriteLine ("OnDeleteActionActivated id={0} nombre={1}",id,nombre);

	}
}
