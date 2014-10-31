using System;
using System.Data;
using System.Collections.Generic;
using Gtk;
namespace PArticulo
{
	public class TreeViewTabla  : TreeView
	{
		private ListStore Columnas;
		public TreeViewTabla (List<Campo> campos)
		{
			List<Type> tipos = new List<Type>();
			Type[] ArrayTipos;
			int columna = 0;
			foreach(Campo campo in campos){
				this.AppendColumn (campo.nombre, new CellRendererText (), "text", columna);
				tipos.Add (campo.tipo);
				columna = columna +1;
			}
			ArrayTipos = tipos.ToArray ();
			this.Columnas = new ListStore (ArrayTipos);
			this.Model = this.Columnas;
		}
	}
}

