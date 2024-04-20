using GerenciadorTurma.Domain.Entities;
using GerenciadorTurma.Domain.Interfaces.Services;
using GerenciadorTurma.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                throw new Exception();
                _alunoService.CriarAluno(aluno);
                return Ok();
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
    }
}
