using System;

namespace PReflection
{
	public class Categoria
	{	

		public ulong Id { get; set;}
		[NotBlankAttribute]
		public string  Nombre { get; set;}
		public Categoria (ulong id, string nombre)
		{
			this.Id = id;
			this.Nombre = nombre;
		}
	}
}

