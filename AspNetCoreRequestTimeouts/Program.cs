var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// https://learn.microsoft.com/en-us/aspnet/core/performance/timeouts?view=aspnetcore-8.0

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
