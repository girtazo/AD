//GitHub>@juankza

using Gtk;
using System;
using System.Reflection;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		showInfo(typeof(Categoria));
		showInfo(typeof(Articulo));

		Categoria categoria = new Categoria (33, "Treinta y tres");

		showValues (categoria);

	}

	private void showInfo (Type type)
	{
		Console.WriteLine (type.Name);
		foreach (PropertyInfo pi in type.GetProperties ())
			Console.WriteLine ("PropertyType of {0} > {1}", pi.Name, pi.PropertyType);

		Console.WriteLine ("");
		foreach (FieldInfo fi in type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic))
			//if (fi.IsDefined(typeof(IdAttribute), true))
			Console.WriteLine ("FieldType of {0} > {1}", fi.Name, fi.FieldType);

		Console.WriteLine ("\n");
	}

	private void showValues (object obj)
	{
		Type type = obj.GetType ();
		Console.WriteLine (type.Name);
		foreach (FieldInfo fi in type.GetFields (BindingFlags.Instance | BindingFlags.NonPublic))
			Console.WriteLine ("Value of {0} > {1}", fi.Name, fi.GetValue (obj));

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

	}

}
