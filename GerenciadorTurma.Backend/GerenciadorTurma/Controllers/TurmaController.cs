using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTurma.Service.Aluno.DTOs;
using FluentValidation;
using GerenciadorTurma.Domain.Validators;

namespace GerenciadorTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        private readonly IValidator<Turma> _turmaValidator;
        private readonly IValidator<EditarTurmaRequest> _editarTurmaValidor;
        public TurmaController(ITurmaService turmaService, IValidator<Turma> turmaValidator, IValidator<EditarTurmaRequest> editarTurmaValidator) 
        {
            _turmaService = turmaService;
            _turmaValidator = turmaValidator;
            _editarTurmaValidor = editarTurmaValidator;
        }


        [HttpPost("CriarTurma")]
        public IActionResult CriarTurma(Turma Turma)
        {
            var validacao = _turmaValidator.Validate(Turma);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            return Ok(_turmaService.CriarTurma(Turma));
        }

        [HttpGet("BuscarTurma")]
        public IActionResult BuscarTurma(int id)
        {
            if (id <= 0)
                return BadRequest("ID invalido");

            return Ok(_turmaService.BuscarTurma(id));
        }

        [HttpDelete("ApagarTurma")]
        public IActionResult ApagarTurma(int id)
        {
            if (id <= 0)
                return BadRequest("ID invalido");

            return Ok(_turmaService.DeletarTurma(id));
        }

        [HttpPut("EditarTurma")]
        public IActionResult EditarTurma(EditarTurmaRequest Turma)
        {
            var validacao = _editarTurmaValidor.Validate(Turma);
            if (!validacao.IsValid)
                return BadRequest(validacao.Errors);

            return Ok(_turmaService.EditarTurma(Turma));
        }

        [HttpGet("BuscarTodosTurmas")]
        public IActionResult BuscarTodosTurmas()
        {
            return Ok(_turmaService.BuscarTodasTurmas());
        }

        [HttpPost("AdicionarAlunoaTurma")]
        public IActionResult AdicionarAlunoaTurma(int idAluno, int idTurma)
        {
            if (idAluno <= 0 || idTurma <= 0)
                return BadRequest("ID invalido");

            return Ok(_turmaService.AdicionarAlunoaTurma(idAluno, idTurma));
        }

        [HttpDelete("RemoverAlunoDeTurma")]
        public IActionResult RemoverAlunoDeTurma(int idAluno, int idTurma)
        {
            if (idAluno <= 0 || idTurma <= 0)
                return BadRequest("ID invalido");

            return Ok(_turmaService.RemoverAlunoDeTurma(idAluno, idTurma));
        }

        [HttpGet("BuscarAlunosEmTurma")]
        public IActionResult buscarAlunosEmTurma(int idTurma)
        {
            if (idTurma <= 0)
                return BadRequest("ID invalido");

            return Ok(_turmaService.buscarAlunosEmTurma(idTurma));
        }
    }
}
