using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Minimal.Api.Configurations;
using Minimal.Infra.Data;
using Serilog;

var builder = WebApplication.CreateBuilder();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.UseSerilog((context, services, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "Secret")
    .AddAuthorization()
    .AddFastEndpoints()
    .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString))
    .AddSwagger()
    .AddApplicationServices()
    .AddRepositories();

var app = builder.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
