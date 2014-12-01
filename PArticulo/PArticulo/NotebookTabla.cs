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
		public void Nueva(TreeViewTabla tabla,string nombre){
			HBox etiqueta = new HBox ();
			Button Btncerrar = new  Button (new Image(Stock.Cancel,IconSize.Button));
			Label nombreEtiqueta = new Label (nombre);
			etiqueta.Add (nombreEtiqueta);
			etiqueta.Add (Btncerrar);
			etiqueta.ShowAll ();
			AppendPage (tabla, etiqueta);
			Btncerrar.Clicked += delegate(object sender, EventArgs e) {

				String texto =this.;
				this.Remove (this.PageNum (page));
			};
		}
	}
}

