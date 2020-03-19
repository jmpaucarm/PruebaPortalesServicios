using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;

using Core;
using Core.Data;
using Core.Data.Repositories;
using Core.Dispatchers;
using Core.Mvc;
using Core.RabbitMq;
using Core.Redis;
using Core.Swagger;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenDevCore.DocConfiguration.Repositories;
using OpenDevCore.DocConfiguration.Repositories.DataBaseElements;
using OpenDevCore.DocConfiguration.Services;


using System;
using System.Linq;
using System.Reflection;

namespace OpenDevCore.DocConfiguration
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
            services.AddDbContext<DocConfigurationContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SuiteInfrastructureContext>(item => item.UseSqlServer(Configuration.GetConnectionString("InfrastructureConnection")));
            services.AddScoped<IAppConfigurationRepository, AppConfigurationRepository>();

            services.AddTransient<IConnectionStrings, ConnectionStrings>();
            services.AddTransient<IDatabaseCatalogRepository, DatabaseCatalogRepository>();

            //repositories Scopes
            services.AddScoped<IFieldRepository, FieldRepository>();
            services.AddScoped<ITypeDocumentRepository, TypeDocumentRepository>();
            services.AddScoped<ITypeFolderRepository, TypeFolderRepository>();
            services.AddScoped<ITypeImageRepository, TypeImageRepository>();
            services.AddScoped<ITypeBoxRepository, TypeBoxRepository>();
            services.AddScoped<IFormVersionRepository, FormVersionRepository>();
            services.AddScoped<IWaterMarkRepository, WaterMarkRepository>();

            //services Scopes
            services.AddScoped<ITypeDocumentService, TypeDocumentService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<ITypeFolderService, TypeFolderService>();
            services.AddScoped<ITypeImageService, TypeImageService>();
            services.AddScoped<ITypeBoxService, TypeBoxService>();
            services.AddScoped<IFormVersionService, FormVersionService>();
            services.AddScoped<IWaterMarkService, WaterMarkService>();

            //validation scopes

            services.AddAutoMapper(typeof(Startup));
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
            app.UseBaseResponseMiddleware();
            app.UseServiceId();
            app.UseMvc();



            startupInitializer.InitializeAsync();
        }
    }
}
