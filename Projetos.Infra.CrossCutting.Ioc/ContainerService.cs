using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Projetos.Domain.DTos;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Domain.Interfaces.Repositories;
using Projetos.Infra.CrossCutting.Handlers.Jwt;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Infra.Data.Context;
using Projetos.Infra.Data.Data;
using Projetos.Infra.Data.Repositories;
using Projetos.Service.Interfaces;
using Projetos.Service.Services;
using Projetos.Service.Validators;
using System;
using System.Text;

namespace Projetos.Infra.CrossCutting.Ioc
{
    public static class ContainerService
    {

        public static IServiceCollection AddApplicationServicesCollentions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(INotificationHandler), typeof(NotificationHandler));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddServices();
            services.AddRepositories();

            services.AddValidators();
            services.AddApplicationAuthentication(configuration);
            services.AddHandlers();
            return services;
        }

        #region Validators

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IValidator<FuncionarioDTo>, FuncionarioValidator>();
            services.AddTransient<IValidator<ProjetoMudaStatusDTo>, ProjetoMudaStatusValidator>();
            
            return services;
        }

        #endregion

        #region Services

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            return services;
        }

        #endregion

        #region Repository

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            return services;
        }

        #endregion

        #region Handlers

        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddScoped(typeof(IJwtHandler), typeof(JwtHandler));
            return services;
        }

        #endregion

        #region Authentication 

        public static IServiceCollection AddApplicationAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("JwtHandler:PrivateKey").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     RequireExpirationTime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });
            return services;
        }

        #endregion

        #region Context

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string queryString)
        {
            services.AddDbContext<ProjetoContext>(options => options.UseNpgsql(queryString));
            return services;
        }

        #endregion

    }
}
