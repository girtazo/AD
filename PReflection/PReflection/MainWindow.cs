using System;
using Gtk;
using System.Reflection;

namespace PReflection
{
	public partial class MainWindow : Gtk.Window
	{
		public  MainWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			Build ();
			Type Categoria = typeof(Categoria);
			mostrarAtributos (Categoria);
			Categoria categoria = new Categoria (1,"Muebles");
			showValues (categoria);

		}
		public void showValues(object obj){
			Type type = obj.GetType ();
			PropertyInfo[] propiedades = type.GetProperties ();
			for (int i = 0; i < propiedades.Length; i ++)
			{
				Console.WriteLine("Propiedad Nombre:"+propiedades[i].Name+" Valor:"+propiedades[i].GetValue(obj,null));
			}

		}
		public void mostrarAtributos(Type clase){

			PropertyInfo[] propiedades = clase.GetProperties ();
			for (int i = 0; i < propiedades.Length; i ++)
			{
				Console.WriteLine("Propiedad Nombre:"+propiedades[i].Name+" Tipo:"+propiedades[i].PropertyType);
			}
			FieldInfo[] fields = clase.GetFields (BindingFlags.Instance | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i ++)
			{
				if(fields[i].IsDefined(typeof(IdAttribute),true)){
					Console.WriteLine("Field Nombre:"+fields[i].Name+" Tipo:"+fields[i].FieldType);
				}
			}
		}
		protected void OnDeleteEvent(object sender,DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	}
}

