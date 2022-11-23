using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FakeStoreAPI
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var openApiInfo = new OpenApiInfo()
            {
                Title = "Fake store .NET API",
                Version = description.ApiVersion.ToString(),
                Description = "Fake store API version control",
                Contact = new OpenApiContact()
                {
                    Email = "example@openbootcamp.com",
                    Name = "OBStudent"
                }
            };
            return openApiInfo;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        
    }
}
