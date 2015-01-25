//gitUser> @juankza

using Gtk;
using MySql;
using MySql.Data.MySqlClient;
using SerpisAd;
using System;
using System.Collections.Generic;
using System.Data;

namespace PArticulo
{
	public partial class EditWindow : Gtk.Window
	{
		//GLOBAL VARS
		private MessageDialog msgDialog;

		private IDbCommand dbCommand;

		private string tabPage;

		private List<string> rowSelected;
		private List<string> colsArticulo;
		private List<string> colsCategoria;

		//MAIN FUNCTION
		public EditWindow () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.tabPage = MainWindow.currentPage.ToLower ();
			this.rowSelected = MyWidgetTV.getRowSelected ();
			this.colsArticulo = MyWidgetTV.getColsArticulo ();
			this.colsCategoria = MyWidgetTV.getColsCategoria ();

		}

		//EDIT BOX (NOT FINISHED, BUT WORKS)
		protected void OnBtnInsertClicked (object sender, EventArgs e)
		{
			try{
				if (this.tabPage == "articulo")
				{
					if (textView.Buffer.Text == "")
					{
						textView.Buffer.Text = "INSERT INTO `" +this.tabPage+ "`(`"
							+this.colsArticulo[0]+ "`, `" +this.colsArticulo[1]+ "`, `"
							+this.colsArticulo[2]+ "`, `" +this.colsArticulo[3]+ "`)" +
							"\nVALUES ([value1], [value2], [value3], [value4])";
					}
					else
					{
						textView.Buffer.Text = textView.Buffer.Text +
							"\nINSERT INTO `" +this.tabPage+ "`(`"
							+this.colsArticulo[0]+ "`, `" +this.colsArticulo[1]+ "`, `"
							+this.colsArticulo[2]+ "`, `" +this.colsArticulo[3]+ "`)" +
							"\nVALUES ([value1], [value2], [value3], [value4])";
					}

				}

				if (this.tabPage == "categoria")
				{
					if (textView.Buffer.Text == "")
					{
						textView.Buffer.Text = "INSERT INTO `" +this.tabPage+ "`(`"
							+this.colsCategoria[0]+ "`, `" +this.colsCategoria[1]+ "`)" +
							"\nVALUES ([value1], [value2])";
					}
					else
					{
						textView.Buffer.Text = textView.Buffer.Text +
							"\nINSERT INTO `" +this.tabPage+ "`(`"
							+this.colsCategoria[0]+ "`, `" +this.colsCategoria[1]+ "`)" +
							"\nVALUES ([value1], [value2])";
					}

				}
				
			}
			catch (Exception error){
				Console.WriteLine (error.Message);
			}

		}
		protected void OnBtnUpdateClicked (object sender, EventArgs e)
		{
			try{
				if (this.tabPage == "articulo")
				{
					if (textView.Buffer.Text == "")
					{
						textView.Buffer.Text =
							"UPDATE `" +this.tabPage+ "`" +
							"\nSET `" +this.colsArticulo[0]+ "`='" +this.rowSelected[0]+ "'," +
							"`" +this.colsArticulo[1]+ "`='" +this.rowSelected[1]+ "'," +
							"`" +this.colsArticulo[2]+ "`='" +this.rowSelected[2]+ "'," +
							"`" +this.colsArticulo[3]+ "`='" +this.rowSelected[3]+ "'" +
							"\nWHERE [condition]";
					}
					else
					{
						textView.Buffer.Text = textView.Buffer.Text +
							"\nUPDATE `" +this.tabPage+ "`" +
							"\nSET `" +this.colsArticulo[0]+ "`='" +this.rowSelected[0]+ "'," +
							"`" +this.colsArticulo[1]+ "`='" +this.rowSelected[1]+ "'," +
							"`" +this.colsArticulo[2]+ "`='" +this.rowSelected[2]+ "'," +
							"`" +this.colsArticulo[3]+ "`='" +this.rowSelected[3]+ "'" +
							"\nWHERE [condition]";

					}

				}

				if (this.tabPage == "categoria")
				{
					if (textView.Buffer.Text == "")
					{
						textView.Buffer.Text =
							"UPDATE `" +this.tabPage+ "`" +
							"\nSET `" +this.colsCategoria[0]+ "`='" +this.rowSelected[0]+ "'," +
							"`" +this.colsCategoria[1]+ "`='" +this.rowSelected[1]+ "'" +
							"\nWHERE [condition]";
					}
					else
					{
						textView.Buffer.Text = textView.Buffer.Text +
							"\nUPDATE `" +this.tabPage+ "`" +
							"\nSET `" +this.colsCategoria[0]+ "`='" +this.rowSelected[0]+ "'," +
							"`" +this.colsCategoria[1]+ "`='" +this.rowSelected[1]+ "'" +
							"\nWHERE [condition]";
					}

				}

			}
			catch (Exception error){
				Console.WriteLine (error.Message);
			}

		}
		protected void OnBtnDeleteClicked (object sender, EventArgs e)
		{
			if (textView.Buffer.Text == "") { textView.Buffer.Text =
				"DELETE FROM `" +this.tabPage+ "` \nWHERE [condition]";}
			else { textView.Buffer.Text = textView.Buffer.Text +
				"\nDELETE FROM `" +this.tabPage+ "` \nWHERE [condition]";}

		}
		protected void OnBtnExecuteClicked (object sender, EventArgs e)
		{
			try{
				if (textView.Buffer.Text != ""){
					this.dbCommand = App.Instance.DbConnection.CreateCommand ();
					dbCommand.CommandText = String.Format (
						textView.Buffer.Text); //CREATE, DROP, INSERT, UPDATE, DELETE

					msgDialog = new MessageDialog (
						this, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, "\t\tAre you sure?\t\t");
					msgDialog.Title = "SQL EditWindow";

					if ((ResponseType)msgDialog.Run () == ResponseType.Yes){
						msgDialog.Destroy ();
						dbCommand.ExecuteNonQuery ();

						msgDialog = new MessageDialog (
							this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "\t\tSQL Script Executed Successfully\t\t");
						msgDialog.Title = "SQL EditWindow";
						msgDialog.Run ();
						msgDialog.Destroy ();

					}
					else{ msgDialog.Destroy ();}

				}
				else{
					msgDialog = new MessageDialog (
						this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "\t\tSQL Script Error. Script 'NULL'\t\t");
					msgDialog.Title = "SQL EditWindow";
					msgDialog.Run ();
					msgDialog.Destroy ();

				}
			}
			catch (MySqlException error){
				Console.WriteLine (error.Message);

			}
			catch{
				Console.WriteLine ("Error");
			}

		}

		//EXIT FUNCTION
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			MainWindow mWin = new MainWindow ();
			mWin.ShowAll ();

		}

	}

}

