using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace INSY_API.Data
{
	public class RequestHandler
	{
		private SQLHandler _sqlHandler;

		public RequestHandler()
		{
			_sqlHandler = new SQLHandler();
		}

		public void GetRequest()
		{
			throw new NotImplementedException();
		}

		public void PostRequest(bool? array, string? msg)
		{
			try
			{
				if (array.Value)
				{
					if (msg != null)
					{
						string[] employees = JsonConvert.DeserializeObject<string[]>(msg);

						foreach (string emp in employees)
						{
							_sqlHandler.Post(emp);
						}
					}
					else
					{
						throw new Exception("P0001");
					}
				}
				if (!array.Value || array == null)
				{
					if (msg != null)
					{
						_sqlHandler.Post(msg);
					}
					else
					{
						throw new Exception("P0001");
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
