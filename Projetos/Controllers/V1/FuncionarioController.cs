using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projetos.Domain.DTos;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Interfaces;
using System.Threading.Tasks;

namespace Projetos.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FuncionarioController : AbstractControllerBase
    {

        protected readonly IFuncionarioService _funcionarioService;
        protected INotificationHandler _notificationHandler;

        public FuncionarioController(INotificationHandler notificationHandler, IFuncionarioService funcionarioService) : base(notificationHandler)
        {
            this._funcionarioService = funcionarioService;
            this._notificationHandler = notificationHandler;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("adicionar-funcionario")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Inserir([FromBody] FuncionarioDTo model)
        {
            var func = await _funcionarioService.Salvar(model);
            return QResult(func);
        }

    }
}
