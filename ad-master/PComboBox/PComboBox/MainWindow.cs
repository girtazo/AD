//GitUser>@juankza

using Gtk;
using SerpisAd;
using System;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		ComboBoxHelper comboBoxHelper = new ComboBoxHelper ();
		comboBoxHelper
			.ComboBox (comboBox)
			.Id ((ulong)7)
			.SelectSql ("select id, nombre from categoria")
			.Init ();
		/*
		propertiesAction.Activated += delegate {
			Console.WriteLine("id={0}", comboBox.GetId());
		};
		*/
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}

public class Categoria
{
	public Categoria (int id, string nombre)
	{
		Id = id;
		Nombre = nombre;

	}

	public int Id{ set; get;}
	public string Nombre{ set; get;}

}
