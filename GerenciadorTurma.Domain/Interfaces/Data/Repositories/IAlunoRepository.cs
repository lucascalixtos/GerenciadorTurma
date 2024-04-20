﻿using GerenciadorTurma.Domain.Entities;
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
        void CriarAluno(Aluno aluno);
        Aluno BuscarAluno(int id);
        Aluno DeletarAluno(int id);
        void EditarAluno(EditarAlunoRequest aluno);
        List<Aluno> BuscarTodosAlunos();

    }
}
