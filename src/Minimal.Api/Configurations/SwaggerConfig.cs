using FastEndpoints.Swagger;

namespace Minimal.Api.Configurations;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.SwaggerDocument(o => 
        {
            o.DocumentSettings = s =>
            {
                s.Title = "Api's Endpoints";
                s.Version = "v1.0";
            };
        });
    }
}
