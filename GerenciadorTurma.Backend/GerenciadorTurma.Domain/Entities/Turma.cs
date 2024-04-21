using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Entities
{
    public class Turma: BaseEntity
    {
        public int Curso_id { get; set; }
        public string turma { get; set; }
        public int Ano { get; set; }
    }
}
