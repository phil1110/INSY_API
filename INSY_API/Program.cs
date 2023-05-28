using Microsoft.IdentityModel.Tokens;
using INSY_API.Lib;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
RequestHandler requestHandler = new RequestHandler();

#region GET-Maps
app.MapGet("/", (int? top) => requestHandler.GetRequest(top));
#endregion

#region POST-Maps
app.MapPost("/", (bool? array, string? emp) => requestHandler.PostRequest(array, emp));
#endregion

app.Run();