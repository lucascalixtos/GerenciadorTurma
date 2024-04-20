using GerenciadorTurma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Data.Repositories
{
    public interface IAlunoRepository
    {
        void CriarAluno(Aluno aluno);
        Aluno BuscarAluno(int id);
        Aluno DeletarAluno(int id);
        Aluno EditarAluno(int id);

    }
}
