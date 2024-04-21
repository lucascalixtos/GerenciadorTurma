using FluentValidation;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Validators
{
    public class AlunoDtoValidator: AbstractValidator<AlunoDto>
    {
        public AlunoDtoValidator()
        {
            RuleFor(aluno => aluno.Nome).NotEmpty().WithMessage("O nome do aluno é obrigatório");
            RuleFor(aluno => aluno.Usuario).NotEmpty().WithMessage("O campo usuário é obrigatório");
            RuleFor(aluno => aluno.Id).NotEmpty().WithMessage("O campo Id é obrigatório");
        }
    }
}
