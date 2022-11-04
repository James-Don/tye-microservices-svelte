using user_service;
using user_service.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DbAccess>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Local",
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:5173");
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

// Add services to the container.


var app = builder.Build();
app.UseCors("Local");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/users", (string kw, int page, int size, DbAccess dbAccess) =>
{
    var kws = kw.Split(" ");
    var users = dbAccess.ListUserByKeywords(kws, page, size);
    return users;
});

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
