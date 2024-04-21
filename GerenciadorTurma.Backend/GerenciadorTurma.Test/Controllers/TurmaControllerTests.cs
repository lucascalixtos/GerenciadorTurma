using Xunit;
using Moq;
using GerenciadorTurma.Controllers;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using GerenciadorTurma.Service.Aluno.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FluentValidation.Results;

namespace GerenciadorTurma.Tests.Controllers
{
    public class TurmaControllerTests
    {
        private readonly TurmaController _controller;
        private readonly Mock<ITurmaService> _turmaServiceMock;
        private readonly Mock<IValidator<Turma>> _turmaValidatorMock;
        private readonly Mock<IValidator<EditarTurmaRequest>> _editarTurmaValidatorMock;

        public TurmaControllerTests()
        {
            _turmaServiceMock = new Mock<ITurmaService>();
            _turmaValidatorMock = new Mock<IValidator<Turma>>();
            _editarTurmaValidatorMock = new Mock<IValidator<EditarTurmaRequest>>();

            _controller = new TurmaController(_turmaServiceMock.Object, _turmaValidatorMock.Object, _editarTurmaValidatorMock.Object);
        }

        [Fact]
        public void CriarTurma_ReturnsBadRequest_WhenValidationFails()
        {
            var turma = new Turma(); // turma is not valid
            var errors = new List<ValidationFailure> { new ValidationFailure("Nome", "Nome é obrigatório") };
            _turmaValidatorMock.Setup(v => v.Validate(turma)).Returns(new ValidationResult(errors));

            var result = _controller.CriarTurma(turma) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal(errors, result.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void BuscarTurma_ReturnsBadRequest_WhenIdIsInvalid(int id)
        {
            var result = _controller.BuscarTurma(id) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("ID invalido", result.Value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ApagarTurma_ReturnsBadRequest_WhenIdIsInvalid(int id)
        {
            var result = _controller.ApagarTurma(id) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("ID invalido", result.Value);
        }


        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(-1, 1)]
        [InlineData(1, -1)]
        public void AdicionarAlunoaTurma_ReturnsBadRequest_WhenIdsAreInvalid(int idAluno, int idTurma)
        {
            // Act
            var result = _controller.AdicionarAlunoaTurma(idAluno, idTurma) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("ID invalido", result.Value);
        }


    }
}
