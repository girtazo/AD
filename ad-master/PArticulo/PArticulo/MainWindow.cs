//gitUser> @juankza

using Gtk;
using MySql;
using MySql.Data.MySqlClient;
using PArticulo;
using SerpisAd;
using System;
using System.Collections.Generic;
using System.Data;

public partial class MainWindow: Gtk.Window
{	
	//GLOBAL VARS
	private MessageDialog msgDialog;

	private List<string> pgName = new List<string> ();

	public static string currentPage;

	//MAIN FUNCTION
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		noteBook.SwitchPage += delegate(object o, SwitchPageArgs args) {
			whereIAm();
		
		};

	}

	//MY FUNCTIONS
	private void addNewPage (Widget widget, string label){
		noteBook.AppendPage (widget, new Label (label));

	}
	private void whereIAm ()
	{
		currentPage = whatPgName (noteBook.GetTabLabel (noteBook.GetNthPage (noteBook.CurrentPage)));

	}
	private string whatPgName (Widget widget){
		Label label = (Label)widget;
		return label.LabelProp;

	}
	private void removePage (string str){
		List<string> whatPgOpen = new List<string> ();
		if (noteBook.NPages != 0) {
			for (int i = 0; i < noteBook.NPages; i++) {
				whatPgOpen.Add (whatPgName (noteBook.GetTabLabel (noteBook.GetNthPage (i))));
			}

			int j = 0;
			for (int i = 0; i < whatPgOpen.Count; i++) {
				if (whatPgOpen[i] == str) {
					noteBook.RemovePage (i - j);
					j++;
				}

			}

		}

	}

	//FILE
	protected void OnArchivoActionActivated (object sender, EventArgs e)
	{
		if (this.pgName.Count != 0){ this.pgName.Clear ();}

		if (noteBook.NPages != 0){
			for (int i = 0; i < noteBook.NPages; i++){
				this.pgName.Add (whatPgName (noteBook.GetTabLabel (noteBook.GetNthPage (i))));
			}

			for (int i = 0; i < pgName.Count; i++){
				if (this.pgName[i] == "Articulo"){
					ArticuloCloseAct.Sensitive = true;
				}

				if (this.pgName[i] == "Categoria"){
					CategoriaCloseAct.Sensitive = true;
				}

			}

			List<string> rowSelected = new List<string> ();
			if (rowSelected.Count != 0){ rowSelected.Clear ();}

			rowSelected = MyWidgetTV.getRowSelected ();
			if (rowSelected.Count != 0){ EditarAction.Sensitive = true;}
			else { EditarAction.Sensitive = false;}

		} else {
			ArticuloCloseAct.Sensitive = false;
			CategoriaCloseAct.Sensitive = false;
			EditarAction.Sensitive = false;
		}

	}
	protected void OnArticuloOpenActActivated (object sender, EventArgs e)
	{
		MyWidgetTV myTreeView = new MyWidgetTV ("articulo");
		addNewPage (myTreeView, "Articulo");

	}
	protected void OnCategoriaOpenActActivated (object sender, EventArgs e)
	{
		MyWidgetTV myTreeView = new MyWidgetTV ("categoria");
		addNewPage (myTreeView, "Categoria");

	}
	protected void OnEditActionActivated (object sender, EventArgs e)
	{
		EditWindow eWin = new EditWindow ();
		eWin.ShowAll ();

		this.Destroy ();

	}
	protected void OnRefreshActionActivated (object sender, EventArgs e)
	{
		//NOT IMPLEMENTED AND UNNECESSARY
		//AFTER EDIT, REFRESH ON OPEN ANY TAB

	}
	protected void OnArticuloCloseActActivated (object sender, EventArgs e)
	{
		removePage ("Articulo");
		ArticuloCloseAct.Sensitive = false;

	}
	protected void OnCategoriaCloseActActivated (object sender, EventArgs e)
	{
		removePage ("Categoria");
		CategoriaCloseAct.Sensitive = false;

	}
	protected void OnSalirActionActivated (object sender, EventArgs e)
	{
		this.Destroy ();
		Application.Quit ();
	}

	//TAB
	protected void OnPestanaActActivated (object sender, EventArgs e)
	{
		if (noteBook.NPages != 0){
			CerrarTodoAct.Sensitive = true;
		} else {
			CerrarTodoAct.Sensitive = false;
		}
	}
	protected void OnPestanaAnteriorActActivated (object sender, EventArgs e)
	{
		//NOT IMPLEMENTED

	}
	protected void OnPestanaSiguienteActActivated (object sender, EventArgs e)
	{
		//NOT IMPLEMENTED

	}
	protected void OnCerrarTodoActActivated (object sender, EventArgs e)
	{
		int pgNum = noteBook.NPages;
		for (int i = 0; i < pgNum; i++){
			noteBook.RemovePage (0);

		}

		ArticuloCloseAct.Sensitive = false;
		CategoriaCloseAct.Sensitive = false;

	}

	//ABOUT
	protected void OnAcercaDeActionActivated (object sender, EventArgs e)
	{
		msgDialog = new MessageDialog (
			this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close,
			"PArticulo v0.2 (Alpha)\nCreado por: Juan Cazalilla Costa\nGitUser> @juankza");
		msgDialog.Title = "Acerca De";
		msgDialog.Run ();
		msgDialog.Destroy ();

	}

	//EXIT FUNCTION
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
