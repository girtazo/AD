using System;
using System.Data;
using Gtk;
namespace PArticulo
{
	public class NotebookTabla : Notebook
	{
		private static int deletePages = 0;
		private static int addPages = 0;
		private BaseDatos WindowBaseDatos;
		public NotebookTabla (BaseDatos window)
		{
			WindowBaseDatos = window;
		}
		public void Nueva(TreeViewTabla tabla,string nombre){
			HBox etiqueta = new HBox ();
			Button Btncerrar = new  Button (new Image(Stock.Cancel,IconSize.Button));
			Label nombreEtiqueta = new Label (nombre);
			etiqueta.Add (nombreEtiqueta);
			etiqueta.Add (Btncerrar);
			etiqueta.ShowAll ();
			int index = AppendPage(tabla, etiqueta);
			if(nombre == "Articulo"){
				WindowBaseDatos.opcionArticulo.Sensitive = false;
			} else {
				WindowBaseDatos.opcionCategoria.Sensitive = false;
			}
			NotebookTabla.deletePages--;
			Btncerrar.Clicked += delegate(object sender, EventArgs e) {
				int posicionRelativa = deletePages - addPages;
				// Eliminacion Pagina
				this.RemovePage(index-posicionRelativa);

				// Paginas eliminadas
				NotebookTabla.deletePages++;

				// Paginas Tipos Actuales
				int numero = this.PageNum(tabla);
				if(numero < 0){

					if(nombre == "Articulo"){
						WindowBaseDatos.opcionArticulo.Sensitive = true;
					} else {
						WindowBaseDatos.opcionCategoria.Sensitive = true;
					}
				}
			};
		}
	}
}

