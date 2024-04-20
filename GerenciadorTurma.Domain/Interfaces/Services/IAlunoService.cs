using GerenciadorTurma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTurma.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        void CriarAluno(Aluno aluno);
        Aluno BuscarAluno(int id);
    }
}
