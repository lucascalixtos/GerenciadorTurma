using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Entities
{
    public class AlunoTurma
    {
        public Turma Turma { get; set; }
        public List<AlunoDto> Alunos { get; set; }
        public List<AlunoDto> AlunosForaDaTurma { get; set; }
    }
}
