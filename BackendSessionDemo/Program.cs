using Application;
using BackendSessionDemo;
using BackendSessionDemo.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Change DI Lifetimes for demo
builder.Services.AddTransient<GuidService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GuidMiddleware>();

app.MapControllers();

app.Run();

public class GuidMiddleware
{
    private readonly RequestDelegate _next;

    public GuidMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // This definition is a must, no typos
    // Services are injected using Method Injection
    public async Task InvokeAsync(HttpContext context, GuidService _service)
    {
        Console.WriteLine($"Guid value in Middleware: {_service.Guid}");

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}