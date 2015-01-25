using System;
using Gtk;
using PNotebook;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		ArticuloAction.Activated += delegate {
			MyTreeView myTreeView = new MyTreeView ();
			addPage (myTreeView, "Articulo");
			whatPage(noteBook.GetTabLabel(noteBook.GetNthPage(0)));
			
		};
		
		CategoriaAction.Activated += delegate {
			MyTreeView myTreeView = new MyTreeView ();
			addPage (myTreeView, "Categoria");
			whatPage(myTreeView);

		};

		SalirAction.Activated += delegate {
			Application.Quit ();

		};

	}

	private void addPage (Widget widget, string label){
		noteBook.AppendPage (widget, new Label (label));

	}

	private void whatPage (Widget widget){
		Label label = (Label)widget;
		Console.WriteLine (label.LabelProp);

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
