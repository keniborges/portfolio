using Microsoft.Extensions.Configuration;
using Projetos.Domain.DTos;
using Projetos.Domain.Enums;
using Projetos.Infra.CrossCutting.Handlers.Jwt;
using Projetos.Infra.CrossCutting.Handlers.Notifications;
using Projetos.Service.Interfaces;
using System;

namespace Projetos.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {

        private readonly IJwtHandler _jwtHandler;
        private readonly IConfiguration _configuration;
        private readonly INotificationHandler _notificationHandler;

        public AutenticacaoService(
            IJwtHandler jwtHandler,
            IConfiguration configuration,
            INotificationHandler notificationHandler)
        {
            this._jwtHandler = jwtHandler;
            this._configuration = configuration;
            this._notificationHandler = notificationHandler;
        }

        private LoginResponseDTo Token()
        {
            var jwtResponse = _jwtHandler.GetToken(new JwtHandlerOptions()
            {
                ExpireIn = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_configuration.GetSection("JwtHandler:ExpireInSeconds").Value)).ToLocalTime(),
                JwtPrivateKey = _configuration.GetSection("JwtHandler:PrivateKey").Value
            }, RoleEnum.Administrador.ToString());

            return new LoginResponseDTo()
            {
                AcessToken = jwtResponse.Token,
                ExpiresIn = jwtResponse.ExpireIn
            };
        }

        public LoginResponseDTo GetToken()
        {
            return Token();
        }

    }
}
