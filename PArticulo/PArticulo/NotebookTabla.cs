using System;
using System.Data;
using Gtk;
namespace PArticulo
{
	public class NotebookTabla : Notebook
	{
		private static int deletePages = 0;

		public NotebookTabla ()
		{
		}
		public void Nueva(TreeViewTabla tabla,string nombre){
			HBox etiqueta = new HBox ();
			Button Btncerrar = new  Button (new Image(Stock.Cancel,IconSize.Button));
			Label nombreEtiqueta = new Label (nombre);
			etiqueta.Add (nombreEtiqueta);
			etiqueta.Add (Btncerrar);
			etiqueta.ShowAll ();
			int index = AppendPage(tabla, etiqueta);
			Btncerrar.Clicked += delegate {
				this.RemovePage(index-NotebookTabla.deletePages);
				NotebookTabla.deletePages++;
			};
		}
	}
}

