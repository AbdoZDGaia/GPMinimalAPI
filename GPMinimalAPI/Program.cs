using GPMinimalAPI.EndPointConfigs;
using GPMinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointDefinitions(typeof(WeatherForecast));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseEndpointDefinitions();
app.Run();
