using GerenciadorTurma.Service.Aluno.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Data.Repositories
{
    public interface IAlunoTurmaRepository
    {
        bool AdicionarAlunoaTurma(int idAluno, int idTurma);
        bool VerificarSeAlunoEstaNaTurma(int idAluno, int idTurma);
        bool RemoverAlunoDeTurma(int idAluno, int idTurma);
        List<EditarAlunoRequest> buscarAlunosEmTurma(int idTurma);
    }
}
