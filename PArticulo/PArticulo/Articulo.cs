using System;

namespace PArticulo
{
	public class Articulo
	{
		public UInt64 id;
		public string nombre;
		public object categoria;
		public object precio;
		public Articulo (UInt64 id,string nombre,object categoria,object precio)
		{
			this.id = id;
			this.nombre = nombre;
			this.categoria = categoria;
			this.precio = precio;
			this.categoria = categoria;
		}

	}
}