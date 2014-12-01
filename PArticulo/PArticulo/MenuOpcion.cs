using System;
using Gtk;

namespace PArticulo
{
	public class MenuOpcion : Attribute
	{
		private Gtk.Action value;
		public Gtk.Action Value
		{ 
			get {return value;}
			set{this.value = Value;}
		}
		public MenuOpcion ()
		{

		}
	}
}

