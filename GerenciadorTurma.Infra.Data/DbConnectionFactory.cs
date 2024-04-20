using Microsoft.Data.SqlClient;
using System.Data;
using GerenciadorTurma.Domain.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using GerenciadorTurma.Domain.Interfaces.Infra;

namespace GerenciadorTurma.Infra.Data
{
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private readonly string _connectionString;
        private IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:Default"];
        }

        public IDbConnection CriarConexao()
        {
            IDbConnection conexao = new SqlConnection(_connectionString);
            return conexao;
        }
    }
}