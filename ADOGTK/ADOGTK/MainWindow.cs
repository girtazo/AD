using System;
using Gtk;
using System.Data;

using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		MySqlConnection dbConnection = new MySqlConnection ("DataSource=localhost;Database=dbprueba;User ID=root;Password=sistemas");
		dbConnection.Open ();
		string selectSql = "select * from articulo";
		IDbDataAdapter dbDataAdapter = new MySqlDataAdapter (selectSql, dbConnection);

		DataSet dataset= new DataSet();
		dbDataAdapter.Fill (dataset);

		Show (dataset);

		DataTable dataTable = dataset.Tables [0];
		DataRow dataRow = dataTable.Rows [0];

		dataRow ["nombre"] = DateTime.Now.ToString ();

		new MySqlCommandBuilder (dbDataAdapter);
		dbDataAdapter.Update (dataset);

	}
	public void Show(DataSet dataset){
		DataTable dataTable = dataset.Tables [0];
		foreach(DataColumn dataColumn in dataTable.Columns){
			Console.WriteLine (dataColumn.ColumnName);
		}
		foreach (DataRow dataRow in dataTable.Rows) {
			foreach (DataColumn dataColumn in dataTable.Columns) {
				Console.WriteLine ("{0}={1}", dataColumn.ColumnName,dataRow [dataColumn]);
			}
		}
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
