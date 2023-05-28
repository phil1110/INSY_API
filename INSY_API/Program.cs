using Microsoft.IdentityModel.Tokens;
using INSY_API.Lib;


RequestHandler requestHandler = new RequestHandler();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#region GET-Maps
app.MapGet("/", (int? top) => requestHandler.GetRequest(top));
#endregion

#region POST-Maps
app.MapPost("/", (bool? array, string? emp) => requestHandler.PostRequest(array, emp));
#endregion

app.Run();