//gitUser> @juankza

using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using PCategoria;

public partial class MainWindow: Gtk.Window
{	
	private ListStore listStore;
	private MySqlConnection mySqlConnection;
	private MessageDialog messageDialog;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		this.SetSizeRequest (300, 75);
		entryUser.SetSizeRequest (200, 25);
		entryPwd.SetSizeRequest (200, 25);
		vboxLogin.Visible = true;
		vboxTable.Visible = false;

		treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		listStore = new ListStore (typeof(ulong), typeof(string));

		treeView.Model = listStore; //JavaCode> treeView.setModel(listStore);
		//Habilita multiseleccion
		//treeView.Selection.Mode = SelectionMode.Multiple; 

		treeView.Selection.Changed += delegate
		{
			deleteAction.Sensitive = treeView.Selection.CountSelectedRows () > 0;

		};

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		try{
			this.mySqlConnection.Close ();
		}
		catch{
			Console.WriteLine ("\nError 404 Not Found");
		}
		
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnEntryUserFocusGrabbed (object sender, EventArgs e)
	{
		entryUser.Text = "";
	}

	protected void OnEntryPwdFocusGrabbed (object sender, EventArgs e)
	{
		entryPwd.Text = "";
		entryPwd.Visibility = false;

	}

	protected void OnCheckBoxPwdToggled (object sender, EventArgs e)
	{
		if (entryPwd.Visibility == true) { entryPwd.Visibility = false;}
		else { entryPwd.Visibility = true;}

	}

	protected void OnButtonLoginClicked (object sender, EventArgs e)
	{
		try{
			string connectionString = "Server=localhost;" + "Database=dbprueba;" +
				"User ID=" + entryUser.Text.ToString () + ";" + "Password=" + entryPwd.Text.ToString ();
			this.mySqlConnection = new MySqlConnection (connectionString);
			this.mySqlConnection.Open ();

			this.SetSizeRequest (500, 250);
			vboxLogin.Visible = false;
			vboxTable.Visible = true;

			OnRefreshActionActivated ();

		}
		catch (MySqlException){
			messageDialog = new MessageDialog (
				this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "\t\tConnection Error\t\t\nCannot connect to database");
			messageDialog.Title = "SQL DataBase Error";
			messageDialog.Run ();
			messageDialog.Destroy ();

			entryUser.Text = "";
			entryPwd.Text = "";

		}
		catch{
			Console.WriteLine ("\nError 404 Not Found");
			Application.Quit ();
		}

	}

	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		EditWindow ew = new EditWindow (this.mySqlConnection);
		ew.Show ();

	}

	protected void OnDeleteActionActivated (object sender, EventArgs e)
	{
		TreeIter treeIter;
		treeView.Selection.GetSelected (out treeIter);
		object id = listStore.GetValue (treeIter, 0);
		//object nombre = listStore.GetValue (treeIter, 1);

		messageDialog = new MessageDialog (
			this, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, "\t\t¿Desea eliminar el elemento seleccionado?\t\t");
		messageDialog.Title = "Eliminar";

		if ((ResponseType)messageDialog.Run () == ResponseType.Yes){
			try{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
				mySqlCommand.CommandText =
					string.Format ("DELETE FROM `{0}`.`{1}` WHERE `{1}`.`id` = {2}",
					               mySqlConnection.Database, "categoria", id); //{1}Command> SHOW TABLES
				mySqlCommand.ExecuteNonQuery ();
			}
			catch (MySqlException){
				Console.WriteLine ("SQL Error");
			}

		}

		messageDialog.Destroy ();
		OnRefreshActionActivated ();

	}

	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		OnRefreshActionActivated ();

	}

	protected void OnCloseActionActivated (object sender, EventArgs e)
	{
		listStore.Clear ();

	}
	
	private void OnRefreshActionActivated ()
	{
		try{
			listStore.Clear ();

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "SELECT * FROM categoria";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			while (mySqlDataReader.Read())
			{
				object id = mySqlDataReader ["id"];
				object nombre = mySqlDataReader ["nombre"];
				listStore.AppendValues (id, nombre);
			}
			
			mySqlDataReader.Close ();
		}
		catch (MySqlException){
			Console.WriteLine ("SQL Error");
			listStore.Clear ();
		}
		
	}

}
