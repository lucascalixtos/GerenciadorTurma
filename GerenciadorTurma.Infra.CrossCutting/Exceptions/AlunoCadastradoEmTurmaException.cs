using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.CrossCutting.Exceptions
{
    public class AlunoCadastradoEmTurmaException : Exception
    {
        public AlunoCadastradoEmTurmaException()
            : base(String.Format("Aluno já cadastrado nesta turma"))
        {

        }
    }
}
