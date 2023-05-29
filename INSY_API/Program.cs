using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

using INSY_API.Lib;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
RequestHandler requestHandler = new RequestHandler();

#region GET-Maps
app.MapGet("/", (int? top) => requestHandler.GetRequest(top));
#endregion

#region POST-Maps
app.MapPost("/", async (bool? array, HttpRequest request) =>
{
	StreamReader reader = new StreamReader(request.Body);

	requestHandler.PostRequest(array, await reader.ReadToEndAsync());
}
);
#endregion

app.Run();