using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Projetos.Domain.DTos;
using System.Collections.Generic;

namespace Projetos.Infra.CrossCutting.Ioc
{
    public static class ContainerAppBuilder
    {

        private static IApplicationBuilder UseExceptions(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
                await context.Response.WriteAsJsonAsync(new GenericResponseDto
                {
                    Sucesso = false,
                    Mensagens = new List<string>() { exception.Message }
                }); ;

            }));
            return builder;
        }


        public static IApplicationBuilder Register(this IApplicationBuilder builder)
        {
            builder.UseExceptions();
            builder.UseAuthentication();
            builder.UseAuthorization();
            return builder;
        }
    }
}
