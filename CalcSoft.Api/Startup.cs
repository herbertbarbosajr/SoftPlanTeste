using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcSoft.Api.Interfaces;
using CalcSoft.Api.Models;
using CalcSoft.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CalcSoft.Api
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
                s.SwaggerDoc("calcsoftdoc", new Info
                {
                    Title = "Calculadora Juros - Teste Softplan",
                    Description = "Está API e um exemplo de implemntação de uma calculadora de juros, " +
                        "que serve como teste de implementação em .net para Softplan",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name = "Paulo Henrique Sousa da Silva",
                        Email = "paulo.henrique@softplan.com.br",
                        Url = "https://github.com/pauloofmeta"
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
                su.SwaggerEndpoint("/doc/calcsoftdoc/doc.json", "Calc Soft V1");
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
