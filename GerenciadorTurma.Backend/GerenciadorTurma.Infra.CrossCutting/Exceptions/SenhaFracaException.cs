using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.CrossCutting.Exceptions
{
    public class SenhaFracaException : Exception
    {
        public SenhaFracaException()
        : base(String.Format("Senha fraca, digite uma mais forte"))
        {

        }
    }
}
