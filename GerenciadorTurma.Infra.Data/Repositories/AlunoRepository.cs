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
using GerenciadorTurma.Infra.CrossCutting.Exceptions;
using GerenciadorTurma.Service.Aluno.DTOs;
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

        public  bool CriarAluno(Aluno aluno)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "insert into aluno values(@nome, @usuario, @senha)";
                var retorno = conexao.Execute(query, aluno);
                if (retorno < 0)
                    throw new ErroCriacaoException("Criar");
                return true;
            }
            catch (ErroCriacaoException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeletarAluno(int id)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "delete from aluno where Id=@id";
                var retorno = conexao.Execute(query, new { Id = id });
                if (retorno < 0)
                    throw new ErroCriacaoException("Deletar");
                return true;
            }
            catch (ErroCriacaoException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Aluno> BuscarTodosAlunos()
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "select * from aluno";
                return conexao.Query<Aluno>(query).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EditarAluno(EditarAlunoRequest aluno)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "update aluno " +
                    "set nome = @nome, usuario = @usuario" +
                    " where id = @id";
                var retorno = conexao.Execute(query, aluno);
                if (retorno < 0)
                    throw new ErroCriacaoException("Editar");
                return true;
            }
            catch (ErroCriacaoException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
