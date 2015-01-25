using System;
using Gtk;
using System.Collections.Generic;
using System.Diagnostics;

public partial class MainWindow: Gtk.Window
{	

	//private static readonly Gdk.Color COLOR_GREEN = new Gdk.Color(0, 255, 0);
	//private static readonly Gdk.Color COLOR_WHITE = new Gdk.Color(255, 255, 255);

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();



	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		labelSaludo.LabelProp = "Hola " +entry1.Text.ToString()+ "!";


	}
}
