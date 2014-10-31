using System;
using System.Data;
using Gtk;
namespace PArticulo
{
	public class NotebookTabla : Notebook
	{
		public NotebookTabla ()
		{
		}
		public void PestanyaNueva(TreeViewTabla tabla,string nombre){
			HBox etiqueta = new HBox ();
			Button Btncerrar = new  Button (new Image(Stock.Cancel,IconSize.Button));
			Label nombreEtiqueta = new Label (nombre);
			etiqueta.Add (Btncerrar);
			etiqueta.Add (nombreEtiqueta);
			AppendPage (tabla, etiqueta);
		}
	}
}

