using GerenciadorTurma.FrontEnd.Data;

namespace GerenciadorTurma.FrontEnd.Models
{
    public class AlunoTurma
    {
        public Turma Turma { get; set; }
        public List<AlunoDto> Alunos { get; set; }
        public List<AlunoDto> AlunosForaDaTurma { get; set; }
    }
}
