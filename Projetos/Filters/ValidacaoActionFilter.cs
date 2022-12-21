using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projetos.Domain.DTos;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Projetos.Filters
{
    public class ValidacaoActionFilter : ActionFilterAttribute
    {

        private readonly INotificationHandler _notificationHandler;

        public ValidacaoActionFilter(INotificationHandler notificationHandler)
        {
            this._notificationHandler = notificationHandler;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.ModelState.IsValid)
            {
                var mensagens = new List<string>();
                foreach (var error in filterContext.ModelState.Values)
                    mensagens.Add(error.Errors?.FirstOrDefault()?.ErrorMessage);
                filterContext.Result = new JsonResult(new GenericResponseDto
                {
                    Sucesso = false,
                    Dados = null,
                    Mensagens = mensagens
                });
            }
        }

    }
}
