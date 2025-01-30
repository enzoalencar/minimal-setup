using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Minimal.Features.Users.Commands;
using Minimal.Features.Users.Queries;
using Minimal.Infra.Data;
using Serilog;

var bld = WebApplication.CreateBuilder();
var connectionString = bld.Configuration.GetConnectionString("DefaultConnection");

bld.Host.UseSerilog((context, services, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

bld.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "Secret")
    .AddAuthorization()
    .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString))
    .AddFastEndpoints()
    .SwaggerDocument(o => {
        o.DocumentSettings = s =>
        {
            s.Title = "Api's Endpoints";
            s.Version = "v1.0";
        };
    });

//TODO: Remove this from Program.cs
bld.Services.AddScoped<CreateUser.Handler>();
bld.Services.AddScoped<ListUsers.Handler>();

var app = bld.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
