namespace Projetos.Infra.CrossCutting.Handlers.Jwt
{
    public interface IJwtHandler
    {
        JwtHandlerReponse GetToken(JwtHandlerOptions options, string role = null);
    }
}
