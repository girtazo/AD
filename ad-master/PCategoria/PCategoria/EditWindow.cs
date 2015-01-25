//gitUser> @juankza

using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using PCategoria;

public partial class EditWindow: Gtk.Window
{
	private MessageDialog messageDialog;
	private MySqlConnection mySqlConnection;

	public EditWindow (MySqlConnection mySqlConnection) : base(Gtk.WindowType.Toplevel)
	{
		Build ();

		this.mySqlConnection = mySqlConnection;
		this.SetSizeRequest (750, 250);



	}

	protected void OnExecuteActionActivated (object sender, EventArgs e)
	{

		try{
			if (textView_EW.Buffer.Text != ""){
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
				mySqlCommand.CommandText =
					string.Format (textView_EW.Buffer.Text); //CREATE, DROP, INSERT, UPDATE, DELETE

				messageDialog = new MessageDialog (
					this, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, "\t\tAre you sure?\t\t");
				messageDialog.Title = "SQL EditWindow";

				if ((ResponseType)messageDialog.Run () == ResponseType.Yes){
					messageDialog.Destroy ();
					mySqlCommand.ExecuteNonQuery ();

					messageDialog = new MessageDialog (
						this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "\t\tSQL Script Executed Successfully\t\t");
					messageDialog.Title = "SQL EditWindow";
					messageDialog.Run ();
					messageDialog.Destroy ();

				}
				else{ messageDialog.Destroy ();}

			}
			else{
				messageDialog = new MessageDialog (
					this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "\t\tSQL Script Error. Script 'NULL'\t\t");
				messageDialog.Title = "SQL EditWindow";
				messageDialog.Run ();
				messageDialog.Destroy ();

			}
		}
		catch (MySqlException error){
			Console.WriteLine (error.Message);

		}
		catch{
			Console.WriteLine ("Error");
		}

	}

	protected void OnGoBackActionActivated (object sender, EventArgs e)
	{
		this.Destroy ();

	}
	//CREATE
	protected void OnBtnCreateClicked (object sender, EventArgs e)
	{
		if (textView_EW.Buffer.Text == "") { textView_EW.Buffer.Text =
			"CREATE TABLE [tabName]";}
		else { textView_EW.Buffer.Text = textView_EW.Buffer.Text +
			"\nCREATE TABLE [tabName]";}

	}
	//DROP
	protected void OnBtnDropClicked (object sender, EventArgs e)
	{
		if (textView_EW.Buffer.Text == "") { textView_EW.Buffer.Text =
			"DROP [DATABASE/TABLE] [dbName/tabName]";}
		else { textView_EW.Buffer.Text = textView_EW.Buffer.Text +
			"\nDROP [DATABASE/TABLE] [dbName/tabName]";}

	}
	//INSERT
	protected void OnBtnInsertClicked (object sender, EventArgs e)
	{
		if (textView_EW.Buffer.Text == "") { textView_EW.Buffer.Text =
			"INSERT INTO `[tabName]`(`[column1]`, `[column2]`) VALUES ([value1], [value2])";}
		else { textView_EW.Buffer.Text = textView_EW.Buffer.Text +
			"\nINSERT INTO `[tabName]`(`[column1]`, `[column2]`) VALUES ([value1], [value2])";}

	}
	//UPDATE
	protected void OnBtnUpdateClicked (object sender, EventArgs e)
	{
		if (textView_EW.Buffer.Text == "") { textView_EW.Buffer.Text =
			"UPDATE `[tabName]` SET `[column1]`=[value1], `[column2]`=[value2] WHERE [condition]";}
		else { textView_EW.Buffer.Text = textView_EW.Buffer.Text +
			"\nUPDATE `[tabName]` SET `[column1]`=[value1], `[column2]`=[value2] WHERE [condition]";}

	}
	//DELETE
	protected void OnBtnDeleteClicked (object sender, EventArgs e)
	{
		if (textView_EW.Buffer.Text == "") { textView_EW.Buffer.Text =
			"DELETE FROM `[tabName]` WHERE [condition]";}
		else { textView_EW.Buffer.Text = textView_EW.Buffer.Text +
			"\nDELETE FROM `[tabName]` WHERE [condition]";}

	}
}
