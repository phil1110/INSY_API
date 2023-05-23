using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPut("/", (int? id, string msg) => test(id, msg)) ;

app.Run();

string test(int? id, string msg)
{
	return "Hello " + id;
}