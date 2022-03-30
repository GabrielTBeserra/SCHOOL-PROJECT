using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SCHOOL_PROJECT_INTERFACE
{
    public static class ConfigureSwagger
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SMARtr - Gestão de Treinamentos",
                    Version = "v1",
                    Description = "Gestão de Treinamentos"
                });


                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Informe o Token (Apnas o Token)",
                    Name = "Autorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });


                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                        new string[]{}
                    }
                });
            });
        }
    }
}
