using INSY_API.Lib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

namespace INSY_API.Lib
{
	public class SQLHandler
	{
		SqlConnection _connection;

		public SQLHandler()
		{
			_connection = new SqlConnection(@"Data Source=DESKTOP-VSHDA8I;Integrated Security=True;Connect Timeout=30;Encrypt=False");
		}

		private void ExecuteUse(SqlConnection connection)
		{
			using (SqlCommand command = new SqlCommand("USE Northwind;", _connection))
			{
				command.ExecuteNonQuery();
			}
		}

		#region GET-Requests
		public string Get(string sqlQuery = "SELECT * FROM Employees")
		{
			List<string> jsons = new List<string>();

			_connection.Open();
			ExecuteUse(_connection);

			using (SqlCommand command = new SqlCommand(sqlQuery, _connection))
			{
				// Execute the query and obtain a SqlDataReader
				using (SqlDataReader reader = command.ExecuteReader())
				{
					// Process the retrieved data
					while (reader.Read())
					{
						int employeeId = Convert.IsDBNull(reader["EmployeeID"]) ? -1 : (int)reader["EmployeeID"];
						string lastName = reader["LastName"] as string;
						string firstName = reader["FirstName"] as string;
						string title = reader["Title"] as string;
						string titleOfCourtesy = reader["TitleOfCourtesy"] as string;
						DateTime birthDate = Convert.IsDBNull(reader["BirthDate"]) ? DateTime.MinValue : (DateTime)reader["BirthDate"];
						DateTime hireDate = Convert.IsDBNull(reader["HireDate"]) ? DateTime.MinValue : (DateTime)reader["HireDate"];
						string address = reader["Address"] as string;
						string city = reader["City"] as string;
						string region = reader["Region"] as string;
						string postalCode = reader["PostalCode"] as string;
						string country = reader["Country"] as string;
						string homePhone = reader["HomePhone"] as string;
						string extension = reader["Extension"] as string;
						byte[] photo = reader["Photo"] as byte[];
						string notes = reader["Notes"] as string;
						int reportsTo = Convert.IsDBNull(reader["ReportsTo"]) ? -1 : (int)reader["ReportsTo"];
						string photoPath = reader["PhotoPath"] as string;

						Employee employee = new Employee(
							employeeId,
							lastName,
							firstName,
							title,
							titleOfCourtesy,
							birthDate,
							hireDate,
							address,
							city,
							region,
							postalCode,
							country,
							homePhone,
							extension,
							photo,
							notes,
							reportsTo,
							photoPath
						);


						jsons.Add(JsonConvert.SerializeObject(employee));
					}
				}
			}

			_connection.Close();

			if(jsons.Count == 1)
			{
				return jsons[0];
			}
			else
			{
				return JsonConvert.SerializeObject(jsons.ToArray());
			}
		}
		#endregion

		#region POST-Requests
		public void Post()
		{
			try
			{
				throw new Exception("No Values were provided.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Post(Employee employee)
		{
			_connection.Open();
			ExecuteUse(_connection);

			#region Query creation
			string sqlQuery = "INSERT INTO Employees ("
				+ $"{(employee.LastName == null || employee.LastName == "" ? "" : "LastName,")}"
				+ $"{(employee.FirstName == null || employee.FirstName == "" ? "" : "FirstName,")}"
				+ $"{(employee.Title == null || employee.Title == "" ? "" : "Title,")}"
				+ $"{(employee.TitleOfCourtesy == null || employee.TitleOfCourtesy == "" ? "" : "TitleOfCourtesy,")}"
				+ $"{(employee.BirthDay == new DateTime() ? "" : "BirthDate,")}"
				+ $"{(employee.HireDate == new DateTime() ? "" : "HireDate,")}"
				+ $"{(employee.Address == null || employee.Address == "" ? "" : "Address,")}"
				+ $"{(employee.City == null || employee.City == "" ? "" : "City,")}"
				+ $"{(employee.Region == null || employee.Region == "" ? "" : "Region,")}"
				+ $"{(employee.PostalCode == null || employee.PostalCode == "" ? "" : "PostalCode,")}"
				+ $"{(employee.Country == null || employee.Country == "" ? "" : "Country,")}"
				+ $"{(employee.HomePhone == null || employee.HomePhone == "" ? "" : "HomePhone,")}"
				+ $"{(employee.Extension == null || employee.Extension == "" ? "" : "Extension,")}"
				+ $"{(employee.Photo == null ? "" : "Photo,")}"
				+ $"{(employee.Notes == null || employee.Notes == "" ? "" : "Notes,")}"
				+ $"{(employee.ReportsTo == -1 ? "" : "ReportsTo,")}"
				+ $"{(employee.PhotoPath == null || employee.PhotoPath == "" ? "" : "PhotoPath")})"
				+ $" VALUES ({(employee.LastName == null || employee.LastName == "" ? "" : $"'{employee.LastName}',")}"
				+ $"{(employee.FirstName == null || employee.FirstName == "" ? "" : $"'{employee.FirstName}',")}"
				+ $"{(employee.Title == null || employee.Title == "" ? "" : $"'{employee.Title}',")}"
				+ $"{(employee.TitleOfCourtesy == null || employee.TitleOfCourtesy == "" ? "" : $"'{employee.TitleOfCourtesy}',")}"
				+ $"{(employee.BirthDay == new DateTime() ? "" : $"'{employee.BirthDay}',")}"
				+ $"{(employee.HireDate == new DateTime() ? "" : $"'{employee.HireDate}',")}"
				+ $"{(employee.Address == null || employee.Address == "" ? "" : $"'{employee.Address}',")}"
				+ $"{(employee.City == null || employee.City == "" ? "" : $"'{employee.City}',")}"
				+ $"{(employee.Region == null || employee.Region == "" ? "" : $"'{employee.Region}',")}"
				+ $"{(employee.PostalCode == null || employee.PostalCode == "" ? "" : $"'{employee.PostalCode}',")}"
				+ $"{(employee.Country == null || employee.Country == "" ? "" : $"'{employee.Country}',")}"
				+ $"{(employee.HomePhone == null || employee.HomePhone == "" ? "" : $"'{employee.HomePhone}',")}"
				+ $"{(employee.Extension == null || employee.Extension == "" ? "" : $"'{employee.Extension}',")}"
				+ $"{(employee.Photo == null ? "" : $"'{employee.Photo.ToString()}',")}"
				+ $"{(employee.Notes == null || employee.Notes == "" ? "" : $"'{employee.Notes}',")}"
				+ $"{(employee.ReportsTo == -1 ? "" : $"{employee.ReportsTo},")}"
				+ $"{(employee.PhotoPath == null || employee.PhotoPath == "" ? "" : $"'{employee.PhotoPath}'")})";
			#endregion
			try
			{
				using (SqlCommand command = new SqlCommand(sqlQuery, _connection))
				{
					command.ExecuteNonQuery();
					//try
					//{
					//	command.ExecuteNonQuery();
					//}
					//catch (Exception ex)
					//{
					//	Debug.WriteLine(ex);
					//}
				}

				_connection.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{
				_connection.Close();
			}
		}

		public void Post(string emp)
		{
			try
			{
				Employee employee = JsonConvert.DeserializeObject<Employee>(emp);

				Post(employee);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		#endregion

		#region PUT-Requests
		public string Put()
		{
			try
			{
				throw new Exception("No parameters existed.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return ex.Message;
			}
		}

		public string Put(Dictionary<string, string> args, Dictionary<string, string> parameters)
		{
			string returnValue = "";

			try
			{
				string setValues = "";
				string whereValues = "";
				string sqlQuery = "";

				foreach (string key in args.Keys)
				{
					string value = args[key];

					if (setValues == "")
					{
						setValues += (value != "" && value != null ? $"{key} = '{value}'" : "");
					}
					else
					{
						setValues += (value != "" && value != null ? $", {key} = '{value}'" : "");
					}
				}

				foreach (string key in parameters.Keys)
				{
					string value = parameters[key];

					if (whereValues == "")
					{
						whereValues += (value != "" && value != null ? $"{key} = '{value}'" : "");
					}
					else
					{
						whereValues += (value != "" && value != null ? $" AND {key} = '{value}'" : "");
					}
				}

				sqlQuery = "UPDATE Employees SET " + setValues + " WHERE " + whereValues;

				using (SqlCommand command = new SqlCommand(sqlQuery, _connection))
				{
					_connection.Open();
					ExecuteUse(_connection);

					command.ExecuteNonQuery();
				}

				returnValue = "Success!";
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				returnValue = ex.Message;
			}
			finally
			{
				_connection.Close();
			}

			return returnValue;
		}
		#endregion
	}
}
