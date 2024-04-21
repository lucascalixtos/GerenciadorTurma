using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTurma.Service.Aluno.DTOs;
using FluentValidation;

namespace GerenciadorTurma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        private readonly IValidator<Aluno> _alunoValidator;
        private readonly IValidator<AlunoDto> _alunoDtoValidator;
        public AlunoController(IAlunoService alunoService, IValidator<Aluno> alunoValidator, IValidator<AlunoDto> alunoDtoValidator)
        {
            _alunoService = alunoService;
            _alunoValidator = alunoValidator;
            _alunoDtoValidator = alunoDtoValidator;
        }

        [HttpPost("CriarAluno")]
        public IActionResult CriarAluno(Aluno aluno)
        {
            var validacao = _alunoValidator.Validate(aluno);
            if (!validacao.IsValid) 
                return BadRequest(validacao.Errors);

            return Ok(_alunoService.CriarAluno(aluno));
        }

        [HttpGet("BuscarAluno")]
        public IActionResult BuscarAluno(int id)
        {
            if (id <= 0)
                return BadRequest("ID invalido");

            return Ok(_alunoService.BuscarAluno(id));
        }

        [HttpDelete("ApagarAluno")]
        public IActionResult ApagarAluno(int id)
        {
            if (id <= 0)
                return BadRequest("ID invalido");

            return Ok(_alunoService.DeletarAluno(id));
        }

        [HttpPut("EditarAluno")]
        public IActionResult EditarAluno(AlunoDto aluno)
        {
            var validacao = _alunoDtoValidator.Validate(aluno);
            if (!validacao.IsValid)
              return BadRequest(validacao.Errors);

            return Ok(_alunoService.EditarAluno(aluno));
        }

        [HttpGet("BuscarTodosAlunos")]
        public IActionResult BuscarTodosAlunos()
        {
            return Ok(_alunoService.BuscarTodosAlunos());
        }
    }
}
