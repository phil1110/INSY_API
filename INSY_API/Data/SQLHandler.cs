using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace INSY_API.Data
{
	public class SQLHandler
	{
		SqlConnection _connection;

		public SQLHandler()
		{
			_connection = new SqlConnection(@"Data Source=DESKTOP-VSHDA8I;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

		public string Get ()
		{
			return null;
		}
	}
}
