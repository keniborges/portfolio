using System.ComponentModel.DataAnnotations;

namespace Projetos.Domain.Enums
{
    public enum CargoEnum
    {
        [Display(Name = "Funcionário")]
        Funcionario,

        [Display(Name = "Gerente")]
        Gerente
    }
}
