using GPMinimalAPI.EndPointConfigs;
using GPMinimalAPI.Options;
using Microsoft.OpenApi.Models;

namespace GPMinimalAPI.EndpointDefinitions
{
    public class SwaggerEndpointDefinitions : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            var swaggerOptions = new SwaggerOptions();
            app.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerOptions.JsonRoute;
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "GP API", Version = "v1" });
            });

        }
    }
}
