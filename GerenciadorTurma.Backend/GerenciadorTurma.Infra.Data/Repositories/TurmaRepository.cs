﻿using Dapper;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Infra;
using GerenciadorTurma.Infra.CrossCutting.Exceptions;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public TurmaRepository(IDbConnectionFactory dbConnectionFactory) 
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        public List<Turma> BuscarTodasTurmas()
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "select * from turma";
                return conexao.Query<Turma>(query).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Turma BuscarTurma(int id)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "select * from turma where Id=@id";
                return conexao.Query<Turma>(query, new { Id = id }).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CriarTurma(Turma turma)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "insert into turma values(@curso_id, @turma, @ano)";
                var retorno = conexao.Execute(query, turma);
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

        public bool DeletarTurma(int id)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();

                string queryAlunoTurma = "delete from aluno_turma where turma_id=@id";
                conexao.Execute(queryAlunoTurma, new { Id = id });

                string query = "delete from turma where Id=@id";
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

        public bool EditarTurma(EditarTurmaRequest turma)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "update turma " +
                    "set curso_id = @curso_id, turma = @turma, ano = @ano" +
                    " where id = @id";
                var retorno = conexao.Execute(query, turma);
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

        public bool ValidarAno(int ano)
        {
            try
            {
                if(ano < DateTime.Now.Year)
                    throw new DadoRecorrenteException(ano);
                return true;
            }
            catch(DadoRecorrenteException ex)
            {
                throw ex;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool ValidarNome(string nome)
        {
            try
            {
                var conexao = _dbConnectionFactory.CriarConexao();
                string query = "select count(turma) from turma where turma = @nome";
                bool retorno = conexao.Query<bool>(query, new { nome = nome }).FirstOrDefault();
                if (retorno)
                    throw new DadoRecorrenteException("Turma", nome);
                return retorno;

            }
            catch (DadoRecorrenteException ex)
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
