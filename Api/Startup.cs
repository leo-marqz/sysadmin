using System;
using Api.Helpers;
using Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
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
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSwaggerGen();
            services.AddCors((options) =>
            {
                options.AddPolicy("CorsIN", (rule) =>
                {
                    rule.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("*");
                });
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseDeveloperExceptionPage();
            }


            app.UseMiddleware<EndpointMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            try
            {
                // Obtener la lista de endpoints
                var endpointDataSource = app.ApplicationServices.GetRequiredService<EndpointDataSource>();
                var endpoints = endpointDataSource.Endpoints;

                // Puedes hacer lo que quieras con la lista de endpoints, por ejemplo, imprimir información sobre cada uno
                foreach (var endpoint in endpoints)
                {
                    Console.WriteLine(endpoint.DisplayName);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
