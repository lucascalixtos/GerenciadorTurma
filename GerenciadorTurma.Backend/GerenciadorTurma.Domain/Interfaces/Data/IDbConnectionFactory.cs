using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Infra
{
    public interface IDbConnectionFactory
    {
        IDbConnection CriarConexao();
    }
}
