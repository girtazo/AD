using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
namespace PCategoria
{
	public partial class MySQL : Gtk.Window
	{
		public MySQL () : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

