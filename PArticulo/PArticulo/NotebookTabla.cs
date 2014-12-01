using System;
using System.Data;
using Gtk;
using System.Collections.Generic;
namespace PArticulo
{
	public class NotebookTabla : Notebook
	{
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

			Btncerrar.Clicked += delegate(object sender, EventArgs e) {

				for(int numero = 0;numero< this.NPages;numero++){
					etiqueta = (HBox)this.GetTabLabel(this.GetNthPage(numero));
					Widget[] children = etiqueta.Children;
					nombreEtiqueta = (Label) children[0];
					if(nombreEtiqueta.LabelProp == nombre){
						if (nombre == "Articulo") {
							WindowBaseDatos.opcionArticulo.Sensitive = true;
						} else {
							WindowBaseDatos.opcionCategoria.Sensitive = true;
						}
						this.RemovePage(numero);
						break;
					}
				}
			};
		}
	}
}

