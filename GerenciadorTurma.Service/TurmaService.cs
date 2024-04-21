using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Infra.Data.Repositories;
using GerenciadorTurma.Service.Aluno.DTOs;
using System;

public class TurmaService: ITurmaService
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly IAlunoTurmaRepository _alunoTurmaRepository;
    public TurmaService(ITurmaRepository turmaRepository, IAlunoTurmaRepository alunoTurmaRepository)
	{
        _turmaRepository = turmaRepository;
        _alunoTurmaRepository = alunoTurmaRepository;
	}

    public List<Turma> BuscarTodasTurmas()
    {
        return _turmaRepository.BuscarTodasTurmas();
    }

    public Turma BuscarTurma(int id)
    {
        return _turmaRepository.BuscarTurma(id);
    }

    public bool CriarTurma(Turma turma)
    {
        _turmaRepository.ValidarAno(turma.Ano);
        return _turmaRepository.CriarTurma(turma);
    }

    public bool DeletarTurma(int id)
    {
        return _turmaRepository.DeletarTurma(id);
    }

    public bool EditarTurma(EditarTurmaRequest turma)
    {
        _turmaRepository.ValidarAno(turma.Ano);
        return _turmaRepository.EditarTurma(turma);
    }

    public bool AdicionarAlunoaTurma(int idAluno, int idTurma)
    {
        _alunoTurmaRepository.VerificarSeAlunoEstaNaTurma(idAluno, idTurma);
        return _alunoTurmaRepository.AdicionarAlunoaTurma(idAluno, idTurma);
    }

    public bool RemoverAlunoDeTurma(int idAluno, int idTurma)
    {
        return _alunoTurmaRepository.RemoverAlunoDeTurma(idAluno, idTurma);
    }

   public AlunoTurma buscarAlunosEmTurma(int idTurma)
    {
        AlunoTurma alunoTurma = new AlunoTurma();
        alunoTurma.Turma = _turmaRepository.BuscarTurma(idTurma);
        alunoTurma.Alunos = _alunoTurmaRepository.buscarAlunosEmTurma(idTurma);
        alunoTurma.AlunosForaDaTurma = _alunoTurmaRepository.ObterAlunosForaDaTurma(idTurma);
        return alunoTurma;
    }
}
