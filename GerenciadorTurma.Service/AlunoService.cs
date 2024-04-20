using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Infra.Data.Repositories;
using System.Security.Cryptography;
using BCryptNet = BCrypt.Net.BCrypt;

namespace GerenciadorTurma.Service
{
    public class AlunoService: IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository) {
            _alunoRepository = alunoRepository;
        }

        public Aluno BuscarAluno(int id)
        {
            return _alunoRepository.BuscarAluno(id);
        }

        public  void CriarAluno(Aluno aluno)
        {
            aluno.senha = CriptografarSenha(aluno.senha);
            _alunoRepository.CriarAluno(aluno);
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