using FluentValidation;
using Projetos.Domain.DTos;
using Projetos.Domain.Enums;
using System;

namespace Projetos.Service.Validators
{
    public class FuncionarioValidator : AbstractValidator<FuncionarioDTo>
    {

        public FuncionarioValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O Campo Nome é obrigatório.");
            RuleFor(x => x.Cargo).Must(ValidarTipoFuncionario).WithMessage("O Campo Cargo é inválido. 0: Funcionário, 1: Gerente.");
        }

        private bool ValidarTipoFuncionario(CargoEnum cargo)
        {
            return Enum.IsDefined(typeof(CargoEnum), cargo);
        }

    }
}
