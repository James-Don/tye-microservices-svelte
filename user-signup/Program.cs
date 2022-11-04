using user_service;
using user_service.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var app = builder.Build();
app.UseCors("Local");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.MapPost("/user_info", (UserForm user, DbAccess dbAccess) =>
{
    dbAccess.AddUser(user);
    return "success";
});

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
