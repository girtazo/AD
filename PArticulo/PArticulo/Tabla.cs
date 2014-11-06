using System;
using System.Collections.Generic;
namespace PArticulo
{
	public class Tabla
	{
		private TreeViewTabla treeView;
		private BDTabla bdtabla;
		public NotebookTabla pestanya;
		public string nombre;
		public Tabla (string nombre)
		{
			this.nombre = nombre;
			this.bdtabla = new BDTabla (this.nombre);
			List<Campo> campos = this.bdtabla.getCampos ();
			this.treeView = new TreeViewTabla (campos);
			List<object> valores = this.bdtabla.listar ();
			this.treeView.rellenar (valores);
			this.pestanya = new NotebookTabla();
			this.pestanya.Nueva (this.treeView,this.nombre);
		}
	}
}

