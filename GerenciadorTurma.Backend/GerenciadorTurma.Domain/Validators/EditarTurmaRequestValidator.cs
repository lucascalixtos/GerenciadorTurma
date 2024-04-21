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
    public class EditarTurmaRequestValidator: AbstractValidator<EditarTurmaRequest>
    {
        public EditarTurmaRequestValidator() 
        {
            RuleFor(turma => turma.Ano).GreaterThanOrEqualTo(1000).LessThanOrEqualTo(9999).WithMessage("O campo ano deve ter 4 dígitos");
            RuleFor(turma => turma.Turma).NotEmpty().WithMessage("O campo turma é obrigatório");
            RuleFor(turma => turma.Curso_id).NotEmpty().WithMessage("O Curso_id turma é obrigatório");
            RuleFor(turma => turma.Id).NotEmpty().WithMessage("O Id turma é obrigatório");
        }
    }
}
