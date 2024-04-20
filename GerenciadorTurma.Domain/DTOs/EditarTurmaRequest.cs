using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Service.Aluno.DTOs
{
    public class EditarTurmaRequest
    {
        [Required]
        public int Id { get; set; }
        public string Curso_id { get; set; }
        public string Turma { get; set; }
        public string Ano { get; set; }
    }
}
