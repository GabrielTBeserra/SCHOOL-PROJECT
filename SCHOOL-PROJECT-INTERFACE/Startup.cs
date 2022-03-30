using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCHOOL_PROJECT_COMMON.Configurations.Http;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;
using SCHOOL_PROJECT_INTERFACE.Interceptor;
using SCHOOL_PROJECT_SERVICE.DependencyInjection;

namespace SCHOOL_PROJECT_INTERFACE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MiddlewareInterceptor>();

            // Configuração JWT
            ConfigureJwt.Configure(services, Configuration);

            // Injeção de Dependencias
            ConfigureBindingsDatabaseContext.RegisterBindings(services, Configuration);
            ConfigureBindingsDependencyInjection.RegisterBindings(services, Configuration);

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Configuração Swagger
            ConfigureSwagger.Configure(services);

            var intermediateProvider = services.BuildServiceProvider();
            var acessorContext = intermediateProvider.GetService<IHttpContextAccessor>();
            HttpContextGetter.Configure(acessorContext);


            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("Cors",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dataContext)
        {
            // Run migrations on startup
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("Cors");

            app.UseRouting();

            app.UseMiddleware<MiddlewareInterceptor>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}