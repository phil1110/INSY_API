using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using INSY_API.Lib;
using Newtonsoft.Json;

namespace INSY_API.Test
{
	public class Program
	{
		static void Main(string[] args)
		{
			StartCommunication();
			Console.ReadKey();
		}

		private static async void StartCommunication()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7021/?top=1");
			HttpResponseMessage response = await client.SendAsync(request);

			Employee emp = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());
			Console.Write(JsonConvert.SerializeObject(emp));

			Console.Write("Enter name: ");
			emp.FirstName = Console.ReadLine();

			request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7021/");
			var content = new StringContent(JsonConvert.SerializeObject(emp));
			request.Content = content;
			response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			Console.WriteLine(await response.Content.ReadAsStringAsync());

			Console.ReadKey();
		}
	}
}
