using Microsoft.IdentityModel.Tokens;
using INSY_API.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
RequestHandler requestHandler = new RequestHandler();

#region GET-Maps
app.MapGet("/", () => sqlHandler.Get());
#endregion

#region POST-Maps
app.MapPost("/", (string? emp, bool? array) => "Temp");
#endregion

app.Run();