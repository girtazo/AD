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
			int columna = 0;
			foreach(Campo campo in campos){
				int innerColumn = columna;
				this.AppendColumn (
					campo.nombre, 
					new CellRendererText (),
					new TreeCellDataFunc (
						delegate(TreeViewColumn tree_column, CellRenderer cell,TreeModel tree_model, TreeIter iter) {
							
							object value = ((object [])tree_model.GetValue (iter, 0))[innerColumn];
							if(value == DBNull.Value || value == null)
								((CellRendererText)cell).Text = "null";
							else 
								((CellRendererText)cell).Text =	value.ToString();
						}
					)
				);
				columna = columna +1;
			}
			this.Columnas = new ListStore (typeof(object));
			this.Model = this.Columnas;
		}
		public void rellenar(List<object> valores) {
			foreach (List<object> tupla in valores) {
				try {
					object[] campos = tupla.ToArray();

					Columnas.AppendValues((object)campos);
				} catch (Exception e){
					string mensaje = e.Message;
				}
			}
		}
	}
}

