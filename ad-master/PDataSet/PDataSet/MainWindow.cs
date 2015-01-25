//GitUser>@juankza

using Gtk;
using MySql.Data.MySqlClient;
using SerpisAd;
using System;
using System.Collections.Generic;
using System.Data;

public partial class MainWindow: Gtk.Window
{	
	//private List<object> lista = new List<object>();

	public MainWindow (MySqlConnection mySqlConnection): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		string sqlCommand = "SELECT * FROM articulo";
		MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter (sqlCommand, mySqlConnection);

		DataSet dataSet = new DataSet ();
		mySqlDataAdapter.Fill (dataSet);

		DataTable dataTable = dataSet.Tables [0];

		show (dataTable);

		DataRow dataRow = dataTable.Rows [0];
		dataRow ["nombre"] = DateTime.Now.ToString ();

		new MySqlCommandBuilder (mySqlDataAdapter);
		mySqlDataAdapter.Update (dataSet);

	}

	private void show (DataTable dataTable)
	{


		foreach (DataRow dataRow in dataTable.Rows)
		{
			foreach (DataColumn dataColumn in dataTable.Columns)
			{
				Console.Write ("| {0} = {1} |", dataColumn.ColumnName, dataRow [dataColumn]);

			}
			Console.WriteLine ();
		}

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
