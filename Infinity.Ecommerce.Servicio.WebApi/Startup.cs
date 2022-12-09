using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infinity.Ecommerce.Transversal.Common;
using Infinity.Ecommerce.Transversal.Mapper;
using Infinity.Ecommerce.Infraestructura.Repository;
using Infinity.Ecommerce.Infraestructura.Interface;
using Infinity.Ecommerce.Infraestructura.Data;
using Infinity.Ecommerce.Dominio.Interface;
using Infinity.Ecommerce.Dominio.Core;
using Infinity.Ecommerce.Aplicacion.Inteface;

using Infinity.Ecommerce.Aplicacion.Main;

namespace Infinity.Ecommerce.Servicio.WebApi
{
    public class Startup
    {
        string politicaCor = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var corsBuilder = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.WithMethods("POST","GET","DELETE","PUT");
            corsBuilder.AllowAnyOrigin();
            //corsBuilder.AllowCredentials();

            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            
            services.AddCors(options =>
            {
                options.AddPolicy(politicaCor, corsBuilder.Build());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IClientesApplication, ClientesApplication>();
            services.AddScoped<IClientesDomain, ClientesDomain>();
            services.AddScoped<IClientesRepository, ClientesRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Infinity.Ecommerce.Servicio.WebApi", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions =>
                {
                    var descriptions = apiDescriptions ?? apiDescriptions.ToArray();
                    var first = descriptions.First(); // build relative to the 1st method
                    var parameters = descriptions.SelectMany(d => d.ParameterDescriptions).ToList();

                    first.ParameterDescriptions.Clear();
                    // add parameters and make them optional
                    foreach (var parameter in parameters)
                        if (first.ParameterDescriptions.All(x => x.Name != parameter.Name))
                        {
                            first.ParameterDescriptions.Add(new Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription
                            {
                                ModelMetadata = parameter.ModelMetadata,
                                Name = parameter.Name,
                                ParameterDescriptor = parameter.ParameterDescriptor,
                                Source = parameter.Source,
                                IsRequired = false,
                                DefaultValue = null
                            });
                        }
                    return first;
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Infinity.Ecommerce.Servicio.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(politicaCor);
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
