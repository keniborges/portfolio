using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Projetos.Domain.DTos;
using Projetos.Domain.Interfaces.Infra.Data;
using Projetos.Infra.CrossCutting.Exceptions;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Projetos.Filters
{
    public class QResultActionFilter : IActionFilter, IExceptionFilter
    {
        private readonly INotificationHandler _notificationHandler;
        private readonly IUnitOfWork _unitOfWork;

        public QResultActionFilter(INotificationHandler notificationHandler, IUnitOfWork unitOfWork)
        {
            this._notificationHandler = notificationHandler;
            this._unitOfWork = unitOfWork;
        }

        private void Commit(ref bool success)
        {
            if (success)
            {
                try
                {
                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _notificationHandler.AddNotification(ex.InnerException?.Message);
                    success = false;
                }
            }
            else
            {
                _unitOfWork.RollBack();
            }
        }

        private GenericResponseDto MontarResultDefault(object value = null)
        {
            var success = !_notificationHandler.HasNotifications();
            Commit(ref success);
            var errorsMessages = success ? new List<string>() : _notificationHandler.GetNotifications().Select(x => x.Message).ToList();
            _notificationHandler.DisposeNotifications();

            return new GenericResponseDto
            {
                Sucesso = success,
                Dados = ((JsonResult)value)?.Value,
                Mensagens = errorsMessages
            };
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new JsonResult(MontarResultDefault(context.Result));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidatorException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.ExceptionHandled = true;
                context.Result = new JsonResult(context.Exception.Message);
            }
        }
    }
}
