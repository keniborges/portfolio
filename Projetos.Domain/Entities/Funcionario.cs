using Projetos.Domain.Enums;
using System.Collections.Generic;

namespace Projetos.Domain.Entities
{
    public class Funcionario : BaseEntity
    {
        public string Nome { get; set; }

        public CargoEnum Cargo { get; set; }

        public ICollection<Projeto> Projetos { get; set; }
    }
}
