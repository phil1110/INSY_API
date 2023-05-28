using INSY_API.Lib;
using Newtonsoft.Json;
using System;

namespace INSY_API.Lib
{
	public class RequestHandler
	{
		private SQLHandler _sqlHandler;

		public RequestHandler()
		{
			_sqlHandler = new SQLHandler();
		}

		public string GetRequest(int? top)
		{
			try
			{
				if(top != null)
				{
					return _sqlHandler.Get($"SELECT TOP {top} * FROM Employees");
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
            }

			return null;
		}

		public void PostRequest(bool? array, string msg = null)
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
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
