using FluentValidation;
using GerenciadorTurma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Validators
{
    public class AlunoValidator: AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleFor(aluno => aluno.Nome).NotEmpty().WithMessage("O nome do aluno é obrigatório");
            RuleFor(aluno => aluno.Usuario).NotEmpty().WithMessage("O campo usuário é obrigatório");
            RuleFor(aluno => aluno.senha).NotEmpty().WithMessage("O campo senha é obrigatório");
        }
    }
}
