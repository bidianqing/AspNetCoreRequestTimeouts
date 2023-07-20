using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// https://learn.microsoft.com/en-us/aspnet/core/performance/timeouts?view=aspnetcore-8.0

builder.Services.AddControllers();

builder.Services.AddRequestTimeouts(options =>
{
    options.AddPolicy("default", new RequestTimeoutPolicy
    {
        Timeout = TimeSpan.FromSeconds(3),
        TimeoutStatusCode = 504,
        WriteTimeoutResponse = async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Timeout from MyPolicy2!");
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers().WithRequestTimeout("default");

app.Run();
