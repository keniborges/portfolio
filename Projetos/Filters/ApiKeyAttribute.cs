using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Projetos.Filters
{
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private string ApiKeyName = "x-api-key";
        private string ApiKey = null;
        private readonly IConfiguration _configuration;

        public ApiKeyAttribute(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiKey = _configuration.GetSection("KeyAuthorization:ApiKey").Value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.HttpContext.Response.WriteAsync("Api Key não localizada");
                return;
            }

            if (!ApiKey.Equals(extractedApiKey))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.HttpContext.Response.WriteAsync("Api Key inválida");
                return;
            }
            await next();
        }
    }
}
