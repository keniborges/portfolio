using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projetos.Domain.DTos;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetos.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjetoController : AbstractControllerBase
    {

        protected readonly IFuncionarioService _funcionarioService;
        protected readonly IProjetoService _projetoService;
        protected INotificationHandler _notificationHandler;

        public ProjetoController(INotificationHandler notificationHandler, IFuncionarioService funcionarioService, IProjetoService projetoService) : base(notificationHandler)
        {
            this._projetoService = projetoService;
            this._funcionarioService = funcionarioService;
            this._notificationHandler = notificationHandler;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Route("adicionar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Inserir([FromBody] ProjetoDTo model)
        {
            var func = await _projetoService.Salvar(model);
            return QResult(func);
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [Route("deletar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Deletar([FromBody] long projetoId)
        {
            var func = await _projetoService.Remover(projetoId);
            return QResult(func);
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Route("mudar-status")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> MudarStatus([FromBody] ProjetoMudaStatusDTo model)
        {
            var func = await _projetoService.MudarStatus(model);
            return QResult(func);
        }
    }
}




