using Xunit;
using Moq;
using GerenciadorTurma.Domain.Interfaces.Data.Repositories;
using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Service;
using System.Collections.Generic;
using GerenciadorTurma.Service.Aluno.DTOs;

namespace GerenciadorTurma.Tests.Services
{
    public class AlunoServiceTests
    {
        private readonly AlunoService _alunoService;
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock;

        public AlunoServiceTests()
        {
            _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepositoryMock.Object);
        }

        [Fact]
        public void BuscarAluno_ShouldReturnAluno_WhenIdIsValid()
        {
            // Arrange
            var alunoId = 1;
            var aluno = new Aluno { Id = alunoId, Nome = "Teste" };
            _alunoRepositoryMock.Setup(repo => repo.BuscarAluno(alunoId)).Returns(aluno);

            // Act
            var result = _alunoService.BuscarAluno(alunoId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(aluno, result);
        }

        [Fact]
        public void CriarAluno_ShouldCallRepositoryMethodWithEncryptedPassword()
        {
            // Arrange
            var aluno = new Aluno { Nome = "Teste", senha = "senha" };
            _alunoRepositoryMock.Setup(repo => repo.CriarAluno(It.IsAny<Aluno>())).Returns(true);

            // Act
            _alunoService.CriarAluno(aluno);

            // Assert
            _alunoRepositoryMock.Verify(repo => repo.CriarAluno(It.Is<Aluno>(a => a.senha != "senha")), Times.Once);
        }

        // Teste para o método BuscarTodosAlunos
        [Fact]
        public void BuscarTodosAlunos_ShouldReturnListOfAlunos()
        {
            // Arrange
            var alunos = new List<Aluno> { new Aluno { Id = 1, Nome = "Aluno1" }, new Aluno { Id = 2, Nome = "Aluno2" } };
            _alunoRepositoryMock.Setup(repo => repo.BuscarTodosAlunos()).Returns(alunos);

            // Act
            var result = _alunoService.BuscarTodosAlunos();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(alunos, result);
        }

        // Teste para o método EditarAluno
        [Fact]
        public void EditarAluno_ShouldReturnTrue_WhenEditingSucceeds()
        {
            // Arrange
            var alunoDto = new AlunoDto { Id = 1, Nome = "Aluno1" };
            _alunoRepositoryMock.Setup(repo => repo.EditarAluno(alunoDto)).Returns(true);

            // Act
            var result = _alunoService.EditarAluno(alunoDto);

            // Assert
            Assert.True(result);
        }


    }
}
