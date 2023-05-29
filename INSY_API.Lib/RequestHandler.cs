using INSY_API.Lib;
using Newtonsoft.Json;
using System;
using System.Data.SqlTypes;

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
				if((top.HasValue ? true : false))
				{
					return _sqlHandler.Get($"SELECT TOP {top} * FROM Employees");
				}
				else { return _sqlHandler.Get(); }
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
            }

			return "";
		}

		public string PostRequest(bool? array, string msg)
		{
			try
			{
				if ((array.HasValue ? array.Value : false))
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
				if ((array.HasValue ? array.Value : true))
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

				return "Success";
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return "Failed";
		}
	}
}
