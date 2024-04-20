using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Data.Repositories
{
    public interface ITurmaRepository
    {
        void CriarTurma(Turma aluno);
        Aluno BuscarTurma(int id);
        Aluno DeletarTurma(int id);
        void EditarTurma(EditarTurmaRequest aluno);
        List<Turma> BuscarTodasTurmas();
    }
}
