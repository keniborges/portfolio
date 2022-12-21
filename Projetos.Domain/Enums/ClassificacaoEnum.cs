using System.ComponentModel.DataAnnotations;

namespace Projetos.Domain.Enums
{
    public enum ClassificacaoEnum
    {
        [Display(Name = "Baixo Risco")]
        BaixoRisco,

        [Display(Name = "Médio Risco")]
        MedioRisco,

        [Display(Name = "Alto Risco")]
        AltoRisco
    }
}
