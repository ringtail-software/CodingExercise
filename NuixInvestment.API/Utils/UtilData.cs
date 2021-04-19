using System.Data.SqlClient;

namespace NuixInvestment.API.Utils
{
	public class UtilData
	{
		public static SqlConnection OpenDefaultConn(string defaultConnection)
		{
			var cn = new SqlConnection(defaultConnection);
			cn.Open();

			return cn;
		}
	}
}