using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTurma.Service.Aluno.DTOs;

namespace GerenciadorTurma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService) {
            _alunoService = alunoService;
        }

        [HttpPost("CriarAluno")]
        public IActionResult CriarAluno(Aluno aluno)
        {
            try
            {
                return Ok(_alunoService.CriarAluno(aluno));
            }
            catch (Exception e)
            {
                throw;
            }
     
        }

        [HttpGet("BuscarAluno")]
        public IActionResult BuscarAluno(int id)
        {
            return Ok(_alunoService.BuscarAluno(id));
        }

        [HttpDelete("ApagarAluno")]
        public IActionResult ApagarAluno(int id)
        {
            return Ok(_alunoService.DeletarAluno(id));
        }

        [HttpPut("EditarAluno")]
        public IActionResult EditarAluno(AlunoDto aluno)
        {
            return Ok(_alunoService.EditarAluno(aluno));
        }

        [HttpGet("BuscarTodosAlunos")]
        public IActionResult BuscarTodosAlunos()
        {
            return Ok(_alunoService.BuscarTodosAlunos());
        }
    }
}
