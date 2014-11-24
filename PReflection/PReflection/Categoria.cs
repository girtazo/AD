using System;

namespace PReflection
{
	public class Categoria
	{	
		[Id]
		public ulong Id { get; set;}
		public string  Nombre { get; set;}
		public Categoria (ulong id, string nombre)
		{
			this.Id = id;
			this.Nombre = nombre;
		}
	}
}

