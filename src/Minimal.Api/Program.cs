using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = "Secret")
    .AddAuthorization()
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
