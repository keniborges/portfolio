using Projetos.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Projetos.Domain.Entities
{
    public class Projeto : BaseEntity
    {
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime PrevisaoTermino { get; set; }

        public DateTime TerminoReal { get; set; }

        public decimal OrcamentoTotal { get; set; }

        public StatusEnum Status { get; set; }

        public ClassificacaoEnum Classificacao { get; set; }

        public string Gerente { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}
