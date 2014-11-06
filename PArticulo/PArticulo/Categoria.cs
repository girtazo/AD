using System;

namespace PArticulo
{
	public class Categoria
	{
		public UInt64 id;
		public string nombre;
		public Categoria (UInt64 id,string nombre)
		{
			this.id = id;
			this.nombre = nombre;
		}

	}
}