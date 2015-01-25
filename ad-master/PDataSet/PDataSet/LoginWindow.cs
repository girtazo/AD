//GitUser> @juankza

using Gtk;
using MySql;
using MySql.Data.MySqlClient;
using SerpisAd;
using System;
using System.Data;

public partial class LoginWindow : Gtk.Window
{
	//GLOBAL VARS
	private MessageDialog msgDialog;

	//MAIN FUNCTION
	public LoginWindow () : base(Gtk.WindowType.Toplevel)
	{
		this.Build ();

	}

	//SHOW PWD
	protected void OnPwdCheckBtnToggled (object sender, EventArgs e)
	{
		if (pwdEntry.Visibility == true){ pwdEntry.Visibility = false;}
		else { pwdEntry.Visibility = true;}

	}

	//LOGIN
	protected void OnLoginButtonClicked (object sender, EventArgs e)
	{
		try{
			string connectionString = "Server=localhost;" + "Database=dbprueba;" +
				"User ID=" + userEntry.Text.ToString () + ";" + "Password=" + pwdEntry.Text.ToString ();
			MySqlConnection mySqlConnection = new MySqlConnection (connectionString);
			App.Instance.DbConnection = new MySqlConnection (connectionString);
			App.Instance.DbConnection.Open ();

			MainWindow mWin = new MainWindow (mySqlConnection);
			mWin.ShowAll ();

			this.Destroy ();

		}
		catch (MySqlException){
			msgDialog = new MessageDialog (
				this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "\t\tConnection Error\t\t\nCannot connect to database");
			msgDialog.Title = "SQL DataBase Error";
			msgDialog.Run ();
			msgDialog.Destroy ();

			pwdEntry.Text = "";

		}
		catch{
			Console.WriteLine ("\nError 404 Not Found");
			Application.Quit ();

		}

	}

	//EXIT FUNCTION
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}

