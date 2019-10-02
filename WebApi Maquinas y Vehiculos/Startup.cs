using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Application.ModelsDto;
using System;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using Domain.Interfaces.Repositories;
using Infraestructure.Persistance.PostgresSQL.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using System.ComponentModel;
using Autofac;
using Autofac.Core;
using Container = Autofac.Core.Container;
using IContainer = Autofac.IContainer;
using Autofac.Extensions.DependencyInjection;
using WebApi.Empleados.Middleware;

namespace WebApplication1
{
    /// <summary>
    /// Class Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IContainer Container { get; private set; }
        /// <summary>
        /// Constructor Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration Property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// // This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Json
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize);
            //Swagger
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory ;
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName);
            services.AddMvc();
                services.AddSwaggerGen(c => {
                    c.SwaggerDoc("v1", new Info { Title = "Maquinas y Vehiculos API", Version = "V1" });
                    c.IncludeXmlComments(commentsFile);
                });
            // Fin Swagger
            // Automapper - Dependency Injection 
            services.AddAutoMapper(typeof(AutoMapperMappingProfile));
            services.AddAutoMapper(typeof(Application.ModelsDto.AutoMapperMappingProfile));
            // Fin Automapper
            //AutoFac
            services.AddTransient<IListadoInspeccionRepository, ListadoInspeccionRepository>();
            services.AddTransient<IListadoInspeccionService, ListadoInspeccionService>();
            services.AddTransient<IInspeccionService, InspeccionService>();
            services.AddTransient<IInspeccionRepository, InspeccionRepository>();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.Populate(services);

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
            //Fin AutoFac
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Error Http localhost:44324/error/code
                app.UseStatusCodePagesWithReExecute("/error/{0}");
                app.UseExceptionHandler("/error/500");
                app.UseHttpsRedirection();
            //Fin Error Http

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            }); 


        }

    }
}
