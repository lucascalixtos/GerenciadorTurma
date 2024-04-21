using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Entities
{
    [Table("aluno")]
    public class Aluno: BaseEntity
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string senha { get; set; }
    }
}
