using System;

namespace Projetos.Domain.DTos
{
    public class ProjetoDTo
    {
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime PrevisaoTermino { get; set; }

        public DateTime TerminoReal { get; set; }

        public decimal OrcamentoTotal { get; set; }

        public string Gerente { get; set; }

        //public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
