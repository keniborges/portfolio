using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Projetos.Filters;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Projetos.Controllers
{
    [ServiceFilter(typeof(QResultActionFilter))]
    public class AbstractControllerBase : ControllerBase
    {
        private readonly INotificationHandler _notificationHandler;

        public AbstractControllerBase(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        protected object GetValueByClaims(JwtSecurityToken token, string typeClaim)
        {
            var claims = token.Claims.Where(c => c.Type == typeClaim);
            if (claims.Any())
                return claims.FirstOrDefault().Value;
            return null;
        }

        protected JwtSecurityToken GetToken()
        {
            var jwt = (Request.Headers[HeaderNames.Authorization]).FirstOrDefault()?.Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(jwt);
        }

        protected ActionResult QResult(object value = null)
        {
            return new JsonResult(value);
        }
    }
}
