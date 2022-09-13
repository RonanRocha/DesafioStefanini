using DesafioStefanini.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Validations
{
    public  class CidadeValidator : AbstractValidator<Cidade>
    {

        public CidadeValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("Nome da cidade não deve ser nulo")
                .NotEmpty().WithMessage("Nome da cidade não pode ser vazio")
                .MinimumLength(3).WithMessage("Nome da cidade deve ter pelo menos 3 caracteres")
                .MaximumLength(200).WithMessage("Nome da cidade deve ter no máximo 200 caracteres");

            RuleFor(x => x.UF)
                .NotNull().WithMessage("Sigla da cidade não deve ser nulo")
                .NotEmpty().WithMessage("Sigla da cidade não pode ser vazio")
                .MinimumLength(2).WithMessage("Sigla da cidade deve ter pelo menos 2 caracteres")
                .MaximumLength(2).WithMessage("Sigla da cidade deve ter no máximo 2 caracteres");

            
        }
    }
}
