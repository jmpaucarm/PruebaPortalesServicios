using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;

using Consul;
using Core;
using Core.Consul;
using Core.Data;
using Core.Dispatchers;
using Core.Minio;
using Core.Mvc;
using Core.RabbitMq;
using Core.Redis;
using Core.RestEase;
using Core.SharePoint;
using Core.Swagger;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenDEVCore.DocBlobStorage.Proxy;
using OpenDEVCore.DocBlobStorage.Repositories;
using OpenDEVCore.DocBlobStorage.Repositories.DataBaseElements;
using OpenDEVCore.DocBlobStorage.Services;


using System;
using System.Linq;
using System.Reflection;

namespace OpenDEVCore.DocBlobStorage
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //singelton for BDD
            services.AddDbContext<DocBlodStorageContext>(item => item.UseSqlServer
                                 (Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppBlodStorageRepository, AppBlodStorageRepository>();
          

            services.AddAutoMapper(typeof(Startup));


            //Repositories Scopes 
            services.AddScoped<IDocumentFieldRepository, DocumentFieldRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();


            //Services Scopes
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IFolderRepository, FolderRepository>();
            services.AddScoped<IBoxRepository, BoxRepository>();
            services.AddScoped<IBoxService, BoxService>();


            //Third Party Services 
            services.RegisterServiceForwarder<ITypeDocumentService>("docConfig-api");
            services.RegisterServiceForwarder<IConfigurationService>("configuration-api");




            services.AddMinio();
            services.AddSharePoint();


            services.AddMvc(c => c.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddFluentValidation();
          

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var result = new
                    {
                        Code = "EFV001",
                        Message = "Error de validación",
                        Errors = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });

            services.AddCustomMvc();
            services.AddSwaggerDocs();

            //services.AddConsul();
            services.AddRedis();

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.AddSqlClient();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime applicationLifetime,// IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseSessionHandlerMiddleware();
            app.UseErrorHandler();

            app.UseWhen(
                 httpContext => !httpContext.Request.Path.StartsWithSegments("/file"),
                 subApp => subApp.UseBaseResponseMiddleware()
            );

            
            app.UseServiceId();
            app.UseMvc();

            startupInitializer.InitializeAsync();
        }
    }
}
