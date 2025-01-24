using FastEndpoints;
using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints().SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "Api's Endpoints";
        s.Version = "v1.0";
    };
});

var app = bld.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.Run();
