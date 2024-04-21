using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Data.Repositories
{
    public interface IAlunoRepository
    {
        bool CriarAluno(Aluno aluno);
        Aluno BuscarAluno(int id);
        bool DeletarAluno(int id);
        bool EditarAluno(EditarAlunoRequest aluno);
        List<Aluno> BuscarTodosAlunos();

    }
}
