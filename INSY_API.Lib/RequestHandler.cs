﻿using INSY_API.Lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

		private string addToWhere(string where, string value, string valueName)
		{
			if(where == "")
			{
				where = " WHERE " + valueName + " = " + $"'{value}'";
			}
			else
			{
				where += " AND " + valueName + " = " + $"'{value}'";
			}

			return where;
		}

		public Employee[] GetRequest(int? top, int? birthyear, int? hireyear, string city, string country)
		{
			string json = "";
			List<Employee> employees = new List<Employee>();

			try
			{
				string sqlQuery = "SELECT";
				string topQuery = "";
				string from = " * FROM Employees";
				string where = "";

				if(top.HasValue ? true : false)
				{
					topQuery = $" TOP({top.Value})";
				}
				if(birthyear.HasValue ? true : false)
				{
					where = addToWhere(where, Convert.ToString(birthyear.Value), "year(BirthDate)");
				}
				if (hireyear.HasValue ? true : false)
				{
					where = addToWhere(where, Convert.ToString(hireyear.Value), "year(HireDate)");
				}
				if (city != null)
				{
					where = addToWhere(where, city, "City");
				}
				if (country != null)
				{
					where = addToWhere(where, country, "Country");
				}

				try
				{
					sqlQuery += topQuery + from + where;
					json = _sqlHandler.Get(sqlQuery);

					if(topQuery == "" || topQuery == " TOP(1)")
					{
						employees.Add(JsonConvert.DeserializeObject<Employee>(json));
					}
					else
					{
						string[] employeesJson = JsonConvert.DeserializeObject<string[]>(json);

						foreach(string employeeJson in employeesJson)
						{
							employees.Add(JsonConvert.DeserializeObject<Employee>(employeeJson));
						}
					}
				}
				catch
				{
					json = _sqlHandler.Get("SELECT TOP(5) * FROM Employees");

					string[] employeesJson = JsonConvert.DeserializeObject<string[]>(json);

					foreach (string employeeJson in employeesJson)
					{
						employees.Add(JsonConvert.DeserializeObject<Employee>(employeeJson));
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				json = ex.Message;
            }

			return employees.ToArray();		
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

		public string PutRequest(Dictionary<string, string> args, Dictionary<string, string> parameters)
		{
			return _sqlHandler.Put(args, parameters);
		}

		public string DeleteRequest(int id)
		{
			return _sqlHandler.Delete(id);
		}
	}
}
