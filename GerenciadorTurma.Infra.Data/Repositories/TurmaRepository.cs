using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
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
        public List<Turma> BuscarTodasTurmas()
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarTurma(int id)
        {
            throw new NotImplementedException();
        }

        public void CriarTurma(Turma aluno)
        {
            throw new NotImplementedException();
        }

        public Aluno DeletarTurma(int id)
        {
            throw new NotImplementedException();
        }

        public void EditarTurma(EditarTurmaRequest aluno)
        {
            throw new NotImplementedException();
        }
    }
}
