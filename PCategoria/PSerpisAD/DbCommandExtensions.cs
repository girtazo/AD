/*using System;
using System.Data;

namespace PSerpisAD
{
	public static class DbCommandExtensions
	{
		public static void AddParameter (IDbCommand dbCommand,string name,object value)
		{
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter (name);
			dbDataParameter.ParameterName = name;
			dbDataParameter.Value = value;
			dbCommand.Parameters.Add (dbDataParameter);
		}
	}
}*/

