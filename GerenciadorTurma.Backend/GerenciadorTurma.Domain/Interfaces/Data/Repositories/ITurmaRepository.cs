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
        bool CriarTurma(Turma turma);
        Turma BuscarTurma(int id);
        bool DeletarTurma(int id);
        bool EditarTurma(EditarTurmaRequest turma);
        List<Turma> BuscarTodasTurmas();
        bool ValidarAno(int ano);
        bool ValidarNome(string nome);
    }
}
