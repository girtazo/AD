using System;
using System.Data;
using Gtk;
using System.Collections.Generic;
using System.Reflection;

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

			Type tipo = WindowBaseDatos.GetType();

			//PropertyInfo[] propiedades = tipo.GetProperties ();
			MenuOpcion[] atributos = (MenuOpcion[])Attribute.GetCustomAttributes(tipo,typeof(MenuOpcion));

			foreach (Modules propiedad in this.get){
				if (propiedad.Name.Substring(0,6) == "opcion") {
					if(nombre == propiedad.Name.Substring(6)){
						Gtk.Action opcion = (Gtk.Action)propiedad.GetValue (WindowBaseDatos,null);
						opcion.Sensitive = false;
					}
				}
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

