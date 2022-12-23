using Projetos.Domain.Enums;

namespace Projetos.Domain.DTos
{
    public class ProjetoMudaStatusDTo
    {
        public long ProjetoId { get; set; }

        public StatusEnum Status { get; set; }
    }
}
