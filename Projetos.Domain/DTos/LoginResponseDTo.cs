using System;

namespace Projetos.Domain.DTos
{
    public class LoginResponseDTo
    {
        public string AcessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
