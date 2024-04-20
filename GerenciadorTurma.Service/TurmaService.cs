using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;

public class TurmaService: ITurmaService
{
	public TurmaService()
	{
	}

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
