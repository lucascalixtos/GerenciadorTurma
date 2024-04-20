using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Infra;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace GerenciadorTurma.Infra.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public AlunoRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public Aluno BuscarAluno(int id)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "select * from aluno where Id=@id";
                return conexao.Query<Aluno>(query, new {Id = id}).FirstOrDefault();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  void CriarAluno(Aluno aluno)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "insert into aluno values(@nome, @usuario, @senha)";
                var retorno = conexao.Execute(query, aluno);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Aluno DeletarAluno(int id)
        {
            throw new NotImplementedException();
        }

        public Aluno EditarAluno(int id)
        {
            throw new NotImplementedException();
        }

    }
}
