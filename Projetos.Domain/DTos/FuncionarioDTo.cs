using Projetos.Domain.Enums;

namespace Projetos.Domain.DTos
{
    public class FuncionarioDTo
    {
        public string Nome { get; set; }

        public CargoEnum Cargo { get; set; }
    }
}
