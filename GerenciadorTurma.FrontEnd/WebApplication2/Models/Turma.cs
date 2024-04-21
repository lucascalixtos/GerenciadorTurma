
namespace GerenciadorTurma.FrontEnd.Models
{
    public class Turma : BaseEntity
    {
        public int Curso_id { get; set; }
        public string turma { get; set; }
        public int Ano { get; set; }
    }
}
