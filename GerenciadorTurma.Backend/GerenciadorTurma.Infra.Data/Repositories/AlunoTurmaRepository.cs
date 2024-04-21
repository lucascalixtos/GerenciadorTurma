using Dapper;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Infra;
using GerenciadorTurma.Infra.CrossCutting.Exceptions;
using GerenciadorTurma.Service.Aluno.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.Data.Repositories
{
    public class AlunoTurmaRepository: IAlunoTurmaRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public AlunoTurmaRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _connectionFactory = dbConnectionFactory;
        }

        public bool AdicionarAlunoaTurma(int idAluno, int idTurma)
        {
            try
            {
                var conexao = _connectionFactory.CriarConexao();
                string query = "insert into aluno_turma values(@idAluno, @idTurma)";
                var retorno = conexao.Execute(query, new { idAluno =  idAluno, idTurma = idTurma});
                if (retorno < 0)
                    throw new ErroCriacaoException("Cadastrar");
                return true;
            }
            catch(ErroCriacaoException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool VerificarSeAlunoEstaNaTurma(int idAluno, int idTurma)
        {
            try
            {
                var conexao = _connectionFactory.CriarConexao();
                string query = "select count(*) from aluno_turma where aluno_id = @idAluno and turma_id = @idTurma";
                var retorno = conexao.Query<bool>(query, new { idAluno = idAluno, idTurma = idTurma}).FirstOrDefault();
                if (retorno)
                    throw new AlunoCadastradoEmTurmaException();
                return retorno;
            }
            catch (AlunoCadastradoEmTurmaException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoverAlunoDeTurma(int idAluno, int idTurma) 
        {
            try
            {
                var conexao = _connectionFactory.CriarConexao();
                string query = "delete from aluno_turma where aluno_id = @idAluno and turma_id = @turma_id";
                var retorno  = conexao.Execute(query, new { idAluno = idAluno, turma_id = idTurma });
                if (retorno < 0)
                    throw new ErroCriacaoException("Deletar");
                return true;
            }
            catch(ErroCriacaoException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<AlunoDto> buscarAlunosEmTurma(int idTurma)
        {
            try
            {
                var conexao = _connectionFactory.CriarConexao();
                string query = " SELECT aluno.id, nome, usuario " +
                    "FROM aluno INNER JOIN aluno_turma ON aluno.id = aluno_turma.aluno_id " +
                    "INNER JOIN turma ON aluno_turma.turma_id = turma.id WHERE turma.id = @idTurma";
                return conexao.Query<AlunoDto>(query, new { idTurma = idTurma }).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<AlunoDto> ObterAlunosForaDaTurma(int idturma)
        {
            try
            {
                var conexao = _connectionFactory.CriarConexao();

                string query = @"
                select *
                from aluno
                where id not in (
                    select aluno_id
                    from aluno_turma
                    where turma_id = @idTurma
                )";

                return conexao.Query<AlunoDto>(query, new { idTurma = idturma }).ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
