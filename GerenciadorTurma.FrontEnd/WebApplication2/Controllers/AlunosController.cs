using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorTurma.FrontEnd.Data;
using GerenciadorTurma.FrontEnd.Models;
using GerenciadorTurma.FrontEnd.Models.Interfaces;

namespace GerenciadorTurma.FrontEnd.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoService _service;

        public AlunosController(IAlunoService alunoService)
        {
            _service = alunoService;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            return View(await _service.BuscarTodosAlunos());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _service.BuscarAluno(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Usuario,senha")] Aluno aluno)
        {
           if (ModelState.IsValid)
            {
                await _service.CriarAluno(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _service.BuscarAluno(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Nome,Usuario,senha, Id")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _service.EditarAluno(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }


        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _service.ApagarAluno(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return RedirectToAction("index");
        }

    }
}
