using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
public partial class Tabla: Gtk.Window
{
	private ListStore campos;
	public Tabla (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		construirTabla ("categoria");
	}
	public void construirTabla(string nombre) {
		IDbCommand sentenciaSQL = App.Instance.MysqlConnection.CreateCommand ();
		sentenciaSQL.CommandText = "Select * from " + nombre;
		IDataReader Lector = sentenciaSQL.ExecuteReader ();
		Console.WriteLine(Lector.GetFieldType ());
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
		}
		tabla.AppendColumn ("id", new CellRendererText (), "text", 0);
		tabla.AppendColumn ("nombre", new CellRendererText (), "text", 1);
		campos = new ListStore (typeof(string), typeof(string));
		tabla.Model = campos;//en java treeView.setModel(listStore)
		tabla.Selection.Changed += seleccionar;

		/*MySqlCommand sentenciaSQL = new MySqlCommand ("Select * from "+tabla);
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
			Lector.Close ();*/
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
