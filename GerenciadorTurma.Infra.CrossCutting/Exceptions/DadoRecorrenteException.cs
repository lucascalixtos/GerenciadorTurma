using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.CrossCutting.Exceptions
{
    public class DadoRecorrenteException : Exception
    {
        public DadoRecorrenteException() { }

        public DadoRecorrenteException(string tipo, string nome)
            : base(String.Format("{0} já cadastrada com o nome {1}", tipo, nome))
        {

        }

        public DadoRecorrenteException(int ano)
            : base(String.Format("Turma já cadastrada no ano {0}", ano))
        {

        }
        public DadoRecorrenteException(string nome)
            : base(String.Format("Aluno {0} já cadastrado nesta turma", nome))
        {

        }

    }
}
