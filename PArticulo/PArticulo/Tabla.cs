using System;
using System.Collections.Generic;
namespace PArticulo
{
	public class Tabla
	{
		private TreeViewTabla treeView;
		private BDTabla bdtabla;
		public string nombre;
		public Tabla (NotebookTabla contenedor,string nombre)
		{
			this.nombre = nombre;
			this.bdtabla = new BDTabla (this.nombre);
			List<Campo> campos = this.bdtabla.getCampos ();
			this.treeView = new TreeViewTabla (campos);
			List<object> valores = this.bdtabla.listar ();
			this.treeView.rellenar (valores);
			contenedor.Nueva (this.treeView,this.nombre);
		}
	}
}

