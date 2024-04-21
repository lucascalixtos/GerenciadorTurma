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
        public int Curso_id { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }
    }
}
