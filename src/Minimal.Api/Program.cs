using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Minimal.Infra.Data;

var bld = WebApplication.CreateBuilder();
var connectionString = bld.Configuration.GetConnectionString("DefaultConnection");

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

var app = bld.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

app.Run();
