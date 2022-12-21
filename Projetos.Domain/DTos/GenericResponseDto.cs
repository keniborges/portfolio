using System.Collections.Generic;

namespace Projetos.Domain.DTos
{
    public class GenericResponseDto
    {
        public bool Sucesso { get; set; }
        public object Dados { get; set; }
        public List<string> Mensagens { get; set; }
    }
}
