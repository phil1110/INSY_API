using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

using INSY_API.Lib;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("*");
					  });
});

var app = builder.Build();



#region GET-Maps
app.MapGet("/", (int? top, int? birthyear, int? hireyear, string? city, string? country) =>
{
	RequestHandler requestHandler = new RequestHandler();

	return requestHandler.GetRequest(top, birthyear, hireyear, city, country);
});
#endregion

#region POST-Maps
app.MapPost("/", async (bool? array, HttpRequest request) =>
{
	RequestHandler requestHandler = new RequestHandler();
	StreamReader reader = new StreamReader(request.Body);

	return requestHandler.PostRequest(array, await reader.ReadToEndAsync());
}
);
#endregion

#region PUT-Maps
app.MapPut("/", (int whereId, string? LastName, string? FirstName, string? Title, 
	string? TitleOfCourtesy, string? BirthDate, string? HireDate, 
	string? Address, string? City, string? Region, 
	string? PostalCode, string? Country, string? HomePhone, 
	string? Extension, string? Photo, string? Notes, 
	int? ReportsTo, string? PhotoPath) =>
{
	Dictionary<string, string> args = new Dictionary<string, string>();
	Dictionary<string, string> parameters = new Dictionary<string, string>();
	RequestHandler requestHandler = new RequestHandler();

	LastName = (LastName == null ? "" : LastName);
	FirstName = (FirstName == null ? "" : FirstName);
	Title = (Title == null ? "" : Title);
	TitleOfCourtesy = (TitleOfCourtesy == null ? "" : TitleOfCourtesy);
	Address = (Address == null ? "" : Address);
	City = (City == null ? "" : City);
	Region = (Region == null ? "" : Region);
	PostalCode = (PostalCode == null ? "" : PostalCode);
	Country = (Country == null ? "" : Country);
	HomePhone = (HomePhone == null ? "" : HomePhone);
	Extension = (Extension == null ? "" : Extension);
	Photo = (Photo == null ? "" : Photo);
	Notes = (Notes == null ? "" : Notes);
	string ReportsToStr = (!ReportsTo.HasValue ? "" : Convert.ToString(LastName));
	PhotoPath = (PhotoPath == null ? "" : PhotoPath);

	args.Add("LastName", LastName);
	args.Add("FirstName", FirstName);
	args.Add("TitleOfCourtesy", TitleOfCourtesy);
	args.Add("Address", Address);
	args.Add("City", City);
	args.Add("Region", Region);
	args.Add("PostalCode", PostalCode);
	args.Add("Country", Country);
	args.Add("HomePhone", HomePhone);
	args.Add("Extension", Extension);
	args.Add("Photo", Photo);
	args.Add("Notes", Notes);
	args.Add("ReportsTo", ReportsToStr);
	args.Add("PhotoPath", PhotoPath);

	parameters.Add("EmployeeID", Convert.ToString(whereId));

	return requestHandler.PutRequest(args, parameters);
});
#endregion

app.MapDelete("/", (int id) =>
{
	RequestHandler requestHandler = new RequestHandler();

	return requestHandler.DeleteRequest(id);
});

app.UseCors(MyAllowSpecificOrigins);

app.Run();