using GerenciadorTurma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Extensions
{
    public static class AlunoExtension
    {
        public static bool ValidarSenhaAluno(this Aluno aluno)
        {
            if (aluno.senha.Length < 8)
                return false;

            if (!Regex.IsMatch(aluno.senha, @"\d"))
                return false;

            if (!Regex.IsMatch(aluno.senha, @"[!@#$%^&*()_+{}\[\]:;<>,.?~]"))
                return false;

            if (!Regex.IsMatch(aluno.senha, @"[A-Z]"))
                return false;

            if (!Regex.IsMatch(aluno.senha, @"[a-z]"))
                return false;

            return true;
        }
    }
}
