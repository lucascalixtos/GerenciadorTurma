using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Service.Aluno.DTOs
{
    public class EditarAlunoRequest
    {
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
    }
}
