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
		}

		private static async void StartCommunication()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7021");

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress);
			request.Properties.Add("top", "1");
			HttpResponseMessage response = await client.SendAsync(request);
			Employee employee = JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());

			Console.Write("Enter Name: ");
			employee.FirstName = Console.ReadLine();

			request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
			request.Properties.Add("msg", JsonConvert.SerializeObject(employee));
			await client.SendAsync(request);

			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
