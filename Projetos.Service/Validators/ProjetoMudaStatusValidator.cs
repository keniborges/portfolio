using FluentValidation;
using Projetos.Domain.DTos;
using Projetos.Domain.Enums;
using System;

namespace Projetos.Service.Validators
{
    public class ProjetoMudaStatusValidator : AbstractValidator<ProjetoMudaStatusDTo>
    {
        public ProjetoMudaStatusValidator()
        {
            RuleFor(x => x.ProjetoId).GreaterThan(0).WithMessage("O Campo Projeto Id deve ser maior que 1.");
            RuleFor(x => x.Status).Must(ValidarStatus).WithMessage("O Campo Status é inválido.");
        }

        private bool ValidarStatus(StatusEnum status)
        {
            return Enum.IsDefined(typeof(StatusEnum), status);
        }
    }
}


