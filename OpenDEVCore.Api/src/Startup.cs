using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using OpenDEVCore.Api.Services;
using Core;
using Core.Authentication;
using Core.Consul;
using Core.Dispatchers;
using Core.Mvc;
using Core.RabbitMq;
using Core.Redis;
using Core.RestEase;
using Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace OpenDEVCore.Api
{
    /// <summary>
    /// StartUp de ApiWateGay
    /// </summary>
    public class Startup
    {
        private static readonly string[] Headers = new []{ "X-Operation", "X-Resource", "X-Total-Count" };
        /// <summary>
        /// Container
        /// </summary>
        public IContainer Container { get; private set; }
        /// <summary>
        /// Interface IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();

            //services.AddConsul();

            services.AddJwt();
            services.AddRedis();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors => 
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithExposedHeaders(Headers));
            });

            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Third party Services
            services.RegisterServiceForwarder<ISecurityService>("security-service");
            services.RegisterServiceForwarder<IConfigurationService>("configuration-service");
            services.RegisterServiceForwarder<IDocConfiguration>("docConfig-service");
            services.RegisterServiceForwarder<IBlobStorageService>("blobStorage-service");



            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();
                    
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="applicationLifetime"></param>
        /// <param name="client"></param>
        /// <param name="startupInitializer"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IApplicationLifetime applicationLifetime, //IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseGatewaySessionHandlerMiddleware();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq();

            //var consulServiceId = app.UseConsul();
            //applicationLifetime.ApplicationStopped.Register(() => 
            //{ 
            //    client.Agent.ServiceDeregister(consulServiceId); 
            //    Container.Dispose(); 
            //});

            startupInitializer.InitializeAsync();
        }
    }
}
