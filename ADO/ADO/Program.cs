using System;
using System.Data;
namespace ADO
{
	class MainClass
	{
		private DataSet dataset;
		private DataTable articulo;
		private DataColumn campos;
		public MainClass(){
			dataset = new DataSet ("dbprueba");
			dataset.
			articulo = new DataTable ("articulo");
			articulo.Columns.Add("");
		}
		public static void Main (string[] args)
		{

		}
}
