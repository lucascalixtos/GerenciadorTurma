using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Extensions;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Infra.CrossCutting.Exceptions;
using GerenciadorTurma.Infra.Data.Repositories;
using GerenciadorTurma.Service.Aluno.DTOs;
using System.Security.Cryptography;
using BCryptNet = BCrypt.Net.BCrypt;

namespace GerenciadorTurma.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public Domain.Entities.Aluno BuscarAluno(int id)
        {
            return _alunoRepository.BuscarAluno(id);
        }

        public bool CriarAluno(Domain.Entities.Aluno aluno)
        {
            if (!aluno.ValidarSenhaAluno())
                throw new SenhaFracaException();

            aluno.senha = CriptografarSenha(aluno.senha);
            return _alunoRepository.CriarAluno(aluno);
        }

        public bool DeletarAluno(int id)
        {
             return _alunoRepository.DeletarAluno(id);
        }

        public List<Domain.Entities.Aluno> BuscarTodosAlunos()
        {
            return _alunoRepository.BuscarTodosAlunos();
        }
        public bool EditarAluno(AlunoDto aluno)
        {
            return _alunoRepository.EditarAluno(aluno);
        }

        private string CriptografarSenha(string senha)
        {
            string senhaCriptografada = BCryptNet.HashPassword(senha);
            return senhaCriptografada;
        }

        private bool validarSenha(string senha, string senhaCriptograda)
        {
            bool senhaCorreta = BCryptNet.Verify(senha, senhaCriptograda);
            return senhaCorreta;
        }

    }
}