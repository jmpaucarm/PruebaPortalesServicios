using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core;
using Core.Dispatchers;
using Core.Mvc;
using Core.RabbitMq;
using Core.Redis;
using Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Consul;
using Consul;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Configuration.Repositories;
using OpenDEVCore.Configuration.Helpers;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using OpenDEVCore.Configuration.Dto;
using OpenDEVCore.Configuration.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using Core.Data;
using Microsoft.Extensions.Options;

namespace Configuration
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
            services.AddContext<ConfigurationSCContext>();

            //services.AddDbContext<ConfigurationSCContext>(item => item.UseSqlServer
            //                     (Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IParameterRepository, ParameterRepository>();

            services.AddSingleton<IValidator<CatalogueDto>, CatalogueValidator>();
            services.AddSingleton<IValidator<CatalogueDetailDto>, CatalogueDetailValidator>();
            services.AddSingleton<IValidator<HolidayDto>, HolidayValidator>();
            services.AddSingleton<IValidator<InstitutionDto>, InstitutionValidator>();
            services.AddSingleton<IValidator<ParameterDto>, ParameterValidator>();

            services.AddSingleton<IExMessages, ExMessages>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();

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

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
            });

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime, IOptions<RedisOptions> options, IOptionsSnapshot<RedisOptions> optionsSnapshot, //IConsulClient client,
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
