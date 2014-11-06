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
			List<Type> tipos = new List<Type> ();
			Type[] ArrayTipos;
			int columna = 0;
			foreach(Campo campo in campos){
				if (columna < 2) {
					this.AppendColumn (campo.nombre, new CellRendererText (), "text", columna);
				} else {
					this.AppendColumn (
						campo.nombre, 
						new CellRendererText (),
						new TreeCellDataFunc (
							delegate(TreeViewColumn tree_column, CellRenderer cell,TreeModel tree_model, TreeIter iter) {
								object value = tree_model.GetValue (iter, 3);
								((CellRendererText)cell).Text = value != DBNull.Value ? value.ToString () : "null";
							}
						)
					);
				}
				tipos.Add (campo.tipo);
				columna = columna +1;
			}
			ArrayTipos = tipos.ToArray ();
			this.Columnas = new ListStore (ArrayTipos);
			this.Model = this.Columnas;
		}
		public void rellenar(List<object> valores) {
			foreach (object tupla in valores) {
				try {
					switch (tupla.GetType().Name) {
						case "Categoria":
							Categoria categoria = (Categoria)tupla;
							Columnas.AppendValues(categoria.id,categoria.nombre);
						break;
						case "Articulo":
							Articulo articulo = (Articulo)tupla;
							if(articulo.precio.GetType().Name == "DBNull"){
								DBNull precio = DBNull.Value;
								if(articulo.categoria.GetType().Name == "DBNull"){
									DBNull categori = DBNull.Value;
									Columnas.AppendValues(articulo.id,articulo.nombre,categori,precio);
								} else {
									Columnas.AppendValues(articulo.id,articulo.nombre,articulo.categoria,precio);
								}
							} else {
								if(articulo.categoria.GetType().Name == "DBNull"){
									DBNull categori = DBNull.Value;
									Columnas.AppendValues(articulo.id,articulo.nombre,categori,articulo.precio);
								} else {
									Columnas.AppendValues(articulo.id,articulo.nombre,articulo.categoria,articulo.precio);
								}
							}
						break;
					}
				} catch (Exception e){
					string mensaje = e.Message;
				}
				//Luis
				// "precio",new CellRenderererText(),new TreeCellDataFunc(
				// delegate(TreeViewColumn tree_column,CellRenderer cell,TreeModel tree_model,TreeIter iter){
				// ((CellRendererText) cell).text =tree_model.GetValue(iter,3).ToString();
				//})
			}
		}
	}
}

