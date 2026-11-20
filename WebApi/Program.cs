using Application.Interfaces;
using Application.Servers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var logDirectory = Path.Combine(builder.Environment.ContentRootPath, "logs");
Directory.CreateDirectory(logDirectory);

builder.Host.UseSerilog((_, loggerConfiguration) => loggerConfiguration
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        Path.Combine(logDirectory, "log-.txt"),
        rollingInterval: RollingInterval.Day));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeReposiyory>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IDepartmentServer, DepartmentService>();
builder.Services.AddScoped<IEmployeeServer, EmployeeService>();
builder.Services.AddScoped<ILeaveRequestServer, LeaveRequestService>();
builder.Services.AddScoped<IPositionServer, PositionService>();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();


    app.Run();


   


