using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Projetos.Filters;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.Controllers.V1
{
    [ApiController]
    //[ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticacaoController : AbstractControllerBase
    {
        private HttpRequest _request;
        private readonly IConfiguration _configuration;
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(INotificationHandler notificationHandler, IAutenticacaoService autenticacaoService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(notificationHandler)
        {
            this._autenticacaoService = autenticacaoService;
            this._configuration = configuration;
            this._request = httpContextAccessor.HttpContext.Request;
        }

        [TypeFilter(typeof(ApiKeyAttribute))]
        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return QResult(_autenticacaoService.GetToken());
        }

    }
}
