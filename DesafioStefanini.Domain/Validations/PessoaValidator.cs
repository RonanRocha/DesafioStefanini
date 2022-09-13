using DesafioStefanini.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioStefanini.Domain.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {

        public PessoaValidator()
        {
            RuleFor(x => x.Nome)
              .NotNull().WithMessage("Nome  não deve ser nulo")
              .NotEmpty().WithMessage("Nome não pode ser vazio")
              .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres")
              .MaximumLength(300).WithMessage("Nome  deve ter no máximo 200 caracteres");

            RuleFor(x => x.Cpf)
                .NotNull().WithMessage("Sigla da cidade não deve ser nulo")
                .NotEmpty().WithMessage("Sigla da cidade não pode ser vazio")
                .IsValidCPF().WithMessage("O Cpf deve ser válido");

            RuleFor(x => x.Idade)
                .NotNull().WithMessage("Idade não deve ser nulo")
                .NotEmpty().WithMessage("Idade não deve ser vazio");

            RuleFor(x => x.Id_Cidade)
                .NotNull().WithMessage("Cidade não deve ser nulo")
                .NotEmpty().WithMessage("Cidade não deve ser vazio");


        }
    }
}
