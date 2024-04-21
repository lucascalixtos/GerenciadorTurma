using Xunit;
using Moq;
using GerenciadorTurma.Controllers;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;
using GerenciadorTurma.Service.Aluno.DTOs;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace GerenciadorTurma.Test.Controllers
{
    public class AlunoControllerTests
    {
        private readonly AlunoController _controller;
        private readonly Mock<IAlunoService> _alunoServiceMock;
        private readonly Mock<IValidator<Aluno>> _alunoValidatorMock;
        private readonly Mock<IValidator<AlunoDto>> _alunoDtoValidatorMock;

        public AlunoControllerTests()
        {
            _alunoServiceMock = new Mock<IAlunoService>();
            _alunoValidatorMock = new Mock<IValidator<Aluno>>();
            _alunoDtoValidatorMock = new Mock<IValidator<AlunoDto>>();

            _controller = new AlunoController(_alunoServiceMock.Object, _alunoValidatorMock.Object, _alunoDtoValidatorMock.Object);
        }

        [Fact]
        public void CriarAluno_ReturnsBadRequest_WhenValidationFails()
        {
            
            var aluno = new Aluno(); // aluno is not valid
            var errors = new List<ValidationFailure> { new ValidationFailure("Nome", "Nome é obrigatório") };
            _alunoValidatorMock.Setup(v => v.Validate(aluno)).Returns(new ValidationResult(errors));

            
            var result = _controller.CriarAluno(aluno) as BadRequestObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal(errors, result.Value);
        }

        [Fact]
        public void BuscarAluno_ReturnsBadRequest_WhenIdIsInvalid()
        {
            
            var invalidId = 0;

            
            var result = _controller.BuscarAluno(invalidId) as BadRequestObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("ID invalido", result.Value);
        }

        [Fact]
        public void ApagarAluno_ReturnsBadRequest_WhenIdIsInvalid()
        {
            
            var invalidId = 0;

            
            var result = _controller.ApagarAluno(invalidId) as BadRequestObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal("ID invalido", result.Value);
        }

        [Fact]
        public void EditarAluno_ReturnsBadRequest_WhenValidationFails()
        {
            
            var alunoDto = new AlunoDto(); // alunoDto is not valid
            var errors = new List<ValidationFailure> { new ValidationFailure("Nome", "Nome é obrigatório") };
            _alunoDtoValidatorMock.Setup(v => v.Validate(alunoDto)).Returns(new ValidationResult(errors));

            
            var result = _controller.EditarAluno(alunoDto) as BadRequestObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.Equal(errors, result.Value);
        }

        [Fact]
        public void BuscarTodosAlunos_ReturnsOk_WithAlunos()
        {
            
            var alunos = new List<Aluno> { new Aluno { Id = 1, Nome = "João" }, new Aluno { Id = 2, Nome = "Maria" } };
            _alunoServiceMock.Setup(s => s.BuscarTodosAlunos()).Returns(alunos);

            
            var result = _controller.BuscarTodosAlunos() as OkObjectResult;

            
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal(alunos, result.Value);
        }
    }
}