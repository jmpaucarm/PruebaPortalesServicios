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
//using Core.Consul;
//using Consul;
using OpenDEVCore.Security.Repositories;
using Microsoft.EntityFrameworkCore;
using OpenDEVCore.Security.Messages.Commands;
using OpenDEVCore.Security.Helpers;
using OpenDEVCore.Security.Services;
using Microsoft.AspNetCore.Identity;
using OpenDEVCore.Security.Entities;
using Core.Authentication;
using Core.Mongo;
using Core.RestEase;
using Microsoft.AspNetCore.Http;
using OpenDEVCore.Security.Proxy;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using System.Linq;
using FluentValidation;
using OpenDEVCore.Security.Dto;
using OpenDEVCore.Security.Validators;
using AutoMapper;
using OpenDEVCore.Security;
using Core.Data;

namespace Security
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
            //services.AddDbContext<SecurityDBContext>(item => item.UseSqlServer
            //                     (Configuration.GetConnectionString("DefaultConnection")));

            services.AddContext<SecurityDBContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.RegisterServiceForwarder<IConfigurationService>("configuration-service");

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // leer header http para manejo sesion

            services.AddSingleton<IValidator<MenuDto>, MenuValidator>();
            services.AddSingleton<IValidator<ProfileDto>, ProfileValidator>();
            services.AddSingleton<IValidator<UserDto>, UserValidator>();


            services.AddCustomMvc();
            services.AddSwaggerDocs();
            //services.AddConsul();
            services.AddRedis();
            services.AddJwt();
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => p.ErrorMessage)).ToList();
                    var result = new
                    {
                        Code = ExMessages.EntityValidationError.code,
                        Message = ExMessages.EntityValidationError.message,
                        Errors = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatchers();
            builder.AddMongo();
            builder.AddMongoRepository<RefreshToken>("RefreshTokens");
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();

            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

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
            app.UseSessionHandlerMiddleware();
            app.UseErrorHandler();
            app.UseBaseResponseMiddleware();
            app.UseServiceId();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseMvc();
            app.UseRabbitMq()
            .SubscribeCommand<UnLock>() //desbloquear por numero de intentos
            .SubscribeCommand<LogSecurityCommand>()  //deconectarse por parte del usuario
            .SubscribeCommand<LockUserCommand>()  //deconectarse por parte del usuario
            .SubscribeCommand<DisconnectUser>() //desconectar por parte del administrador
            .SubscribeCommand<SingOut>(); //cerrar sessión

            //var consulServiceId = app.UseConsul();
            //applicationLifetime.ApplicationStopped.Register(() =>
            //{
            //    client.Agent.ServiceDeregister(consulServiceId);
            //    Container.Dispose();
            //});

            //var esto = client.KV.Get(@"Suite-Credito/Security").Result;
            startupInitializer.InitializeAsync();
        }
    }
}
