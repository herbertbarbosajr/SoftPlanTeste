using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioSoftPlan.Api.Interfaces;
using DesafioSoftPlan.Api.Models;
using DesafioSoftPlan.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DesafioSoftPlan.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IJurosService, JurosService>();

            var configApp = new ConfigApp();
            Configuration.Bind("ConfigApp", configApp);
            services.AddSingleton(configApp);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("DesafioSoftPlandoc", new Info
                {
                    Title = "Desafio para Calcular Juros - Softplan",
                    Description = "Está API simula a implementação de uma calculadora de juros, " +
                        "que serve para calcular o valot utilizando .net para Teste Softplan",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Herbert Barbosa Junior",
                        Email = "hebertbarbosajr@gmail.com",
                        Url = "https://github.com/herbertbarbosajr"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(s => s.RouteTemplate = "doc/{documentName}/doc.json");
            app.UseSwaggerUI(su =>
            {
                su.SwaggerEndpoint("/doc/DesafioSoftPlandoc/doc.json", "Desafio SoftPlan V1");
                su.RoutePrefix = "doc";
            });

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
