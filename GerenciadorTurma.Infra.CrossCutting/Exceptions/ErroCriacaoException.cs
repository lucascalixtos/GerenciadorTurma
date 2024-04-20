using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.CrossCutting.Exceptions
{
    [Serializable]
    public class ErroCriacaoException: Exception
    {
        public ErroCriacaoException() { }

        public ErroCriacaoException(string acao)
            : base(String.Format("Erro ao {0}, tente novamente", acao))
        {

        }
    }
}
