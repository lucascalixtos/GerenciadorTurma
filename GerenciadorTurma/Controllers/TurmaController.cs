using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTurma.Service.Aluno.DTOs;

namespace GerenciadorTurma.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(ITurmaService turmaService) 
        {
            _turmaService = turmaService;
        }


        [HttpPost("CriarTurma")]
        public IActionResult CriarTurma(Turma Turma)
        {
            try
            {
                _turmaService.CriarTurma(Turma);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarTurma")]
        public IActionResult BuscarTurma(int id)
        {
            return Ok(_turmaService.BuscarTurma(id));
        }

        [HttpDelete("ApagarTurma")]
        public IActionResult ApagarTurma(int id)
        {
            _turmaService.DeletarTurma(id);
            return Ok();
        }

        [HttpPut("EditarTurma")]
        public IActionResult EditarTurma(EditarTurmaRequest Turma)
        {
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
            return Ok(_turmaService.AdicionarAlunoaTurma(idAluno, idTurma));
        }

        [HttpDelete("RemoverAlunoDeTurma")]
        public IActionResult RemoverAlunoDeTurma(int idAluno, int idTurma)
        {
            return Ok(_turmaService.RemoverAlunoDeTurma(idAluno, idTurma));
        }

        [HttpGet("buscarAlunosEmTurma")]
        public IActionResult buscarAlunosEmTurma(int idTurma)
        {
            return Ok(_turmaService.buscarAlunosEmTurma(idTurma));
        }
    }
}
