using Xunit;
using Moq;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Service.Aluno.DTOs;
using System.Collections.Generic;

namespace GerenciadorTurma.Tests.Services
{
    public class TurmaServiceTests
    {
        private readonly TurmaService _turmaService;
        private readonly Mock<ITurmaRepository> _turmaRepositoryMock;
        private readonly Mock<IAlunoTurmaRepository> _alunoTurmaRepositoryMock;

        public TurmaServiceTests()
        {
            _turmaRepositoryMock = new Mock<ITurmaRepository>();
            _alunoTurmaRepositoryMock = new Mock<IAlunoTurmaRepository>();
            _turmaService = new TurmaService(_turmaRepositoryMock.Object, _alunoTurmaRepositoryMock.Object);
        }

        [Fact]
        public void BuscarTodasTurmas_ShouldReturnListOfTurmas()
        {
            var turmas = new List<Turma> { new Turma { Id = 1, Ano = 2022 }, new Turma { Id = 2, Ano = 2023 } };
            _turmaRepositoryMock.Setup(repo => repo.BuscarTodasTurmas()).Returns(turmas);

            var result = _turmaService.BuscarTodasTurmas();

            Assert.NotNull(result);
            Assert.Equal(turmas, result);
        }

        [Fact]
        public void BuscarTurma_ShouldReturnTurma_WhenIdIsValid()
        {
            var turmaId = 1;
            var turma = new Turma { Id = turmaId, Ano = 2022 };
            _turmaRepositoryMock.Setup(repo => repo.BuscarTurma(turmaId)).Returns(turma);

            var result = _turmaService.BuscarTurma(turmaId);

            Assert.NotNull(result);
            Assert.Equal(turma, result);
        }

        [Fact]
        public void CriarTurma_ShouldCallRepositoryMethodWithValidYear()
        {
            var turma = new Turma { Ano = 2022 };
            _turmaRepositoryMock.Setup(repo => repo.ValidarAno(turma.Ano));

            _turmaService.CriarTurma(turma);

            _turmaRepositoryMock.Verify(repo => repo.ValidarAno(turma.Ano), Times.Once);
            _turmaRepositoryMock.Verify(repo => repo.CriarTurma(turma), Times.Once);
        }

        [Fact]
        public void DeletarTurma_ShouldReturnTrue_WhenIdIsValid()
        {
            var turmaId = 1;
            _turmaRepositoryMock.Setup(repo => repo.DeletarTurma(turmaId)).Returns(true);

            var result = _turmaService.DeletarTurma(turmaId);

            Assert.True(result);
        }

        [Fact]
        public void EditarTurma_ShouldCallRepositoryMethodWithValidYear()
        {
            var turma = new EditarTurmaRequest { Ano = 2022 };
            _turmaRepositoryMock.Setup(repo => repo.ValidarAno(turma.Ano));

            _turmaService.EditarTurma(turma);

            _turmaRepositoryMock.Verify(repo => repo.ValidarAno(turma.Ano), Times.Once);
            _turmaRepositoryMock.Verify(repo => repo.EditarTurma(turma), Times.Once);
        }

        [Fact]
        public void AdicionarAlunoaTurma_ShouldCallRepositoryMethod_WhenIdsAreValid()
        {
            var idAluno = 1;
            var idTurma = 1;
            _alunoTurmaRepositoryMock.Setup(repo => repo.VerificarSeAlunoEstaNaTurma(idAluno, idTurma)).Returns(false);
            _alunoTurmaRepositoryMock.Setup(repo => repo.AdicionarAlunoaTurma(idAluno, idTurma)).Returns(true);

            var result = _turmaService.AdicionarAlunoaTurma(idAluno, idTurma);

            Assert.True(result);
            _alunoTurmaRepositoryMock.Verify(repo => repo.AdicionarAlunoaTurma(idAluno, idTurma), Times.Once);
        }

        [Fact]
        public void RemoverAlunoDeTurma_ShouldReturnTrue_WhenIdsAreValid()
        {
            var idAluno = 1;
            var idTurma = 1;
            _alunoTurmaRepositoryMock.Setup(repo => repo.RemoverAlunoDeTurma(idAluno, idTurma)).Returns(true);

            var result = _turmaService.RemoverAlunoDeTurma(idAluno, idTurma);

            Assert.True(result);
        }


    }
}
