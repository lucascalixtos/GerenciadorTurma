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
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorTurma.FrontEnd.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ITurmaService _service;

        public TurmasController(ITurmaService TurmaService)
        {
            _service = TurmaService;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            return View(await _service.BuscarTodosTurmas());
        }

        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Turma = await _service.BuscarTurma(id);
            if (Turma == null)
            {
                return NotFound();
            }

            return View(Turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Curso_id,turma,Ano")] Turma turm)
        {
            if (ModelState.IsValid)
            {
                if (turm.Curso_id <= 0)
                {
                    ViewBag.MensagemErro = "O id deve ser maior que 0";
                    return View();
                }

                if (turm.turma.IsNullOrEmpty())
                {
                    ViewBag.MensagemErro = "Preencha o campo turma";
                    return View();
                }

                if (turm.Ano < 1000 || turm.Ano > 9999)
                {
                    ViewBag.MensagemErro = "Digite um ano com 4 dígitos";
                    return View();
                }

                if (turm.Ano < DateTime.Now.Year)
                {
                    ViewBag.MensagemErro = "Digite um ano que seja maior ou igual o atual";
                    return View();
                }

                await _service.CriarTurma(turm);
                return RedirectToAction(nameof(Index));
            }
            return View(turm);
        }

        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Turma = await _service.BuscarTurma(id);
            if (Turma == null)
            {
                return NotFound();
            }
            return View(Turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Curso_id,turma,Ano,Id")] Turma turm)
        {
            if (ModelState.IsValid)
            {
                if (turm.Curso_id <= 0)
                {
                    ViewBag.MensagemErro = "O id deve ser maior que 0";
                    return View();
                }

                if (turm.turma.IsNullOrEmpty())
                {
                    ViewBag.MensagemErro = "Preencha o campo turma";
                    return View();
                }

                if (turm.Ano < 1000 || turm.Ano > 9999)
                {
                    ViewBag.MensagemErro = "Digite um ano com 4 dígitos";
                    return View();
                }

                if (turm.Ano < DateTime.Now.Year)
                {
                    ViewBag.MensagemErro = "Digite um ano que seja maior ou igual o atual";
                    return View();
                }



                await _service.EditarTurma(turm);
                return RedirectToAction(nameof(Index));
            }
            return View(turm);
        }


        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Turma = await _service.ApagarTurma(id);
            if (Turma == null)
            {
                return NotFound();
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> ListaAlunosTurma(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Turma = await _service.BuscarAlunosEmTurma(id);
            if (Turma == null)
            {
                return NotFound();
            }
            return View(Turma);
        }

        public async Task<IActionResult> RemoverAlunoDeTurma(int idAluno, int idTurma)
        {
            if (idAluno == null && idTurma == null)
            {
                return NotFound();
            }

            var Turma = await _service.RemoverAlunoDeTurma(idAluno, idTurma);
            if (Turma == null)
            {
                return NotFound();
            }

            return RedirectToAction("ListaAlunosTurma", new { id = idTurma });
        }

        public async Task<IActionResult> AdicionarAlunoaTurma(int idAluno, int idTurma)
        {
            if (idAluno == null && idTurma == null)
            {
                return NotFound();
            }

            var Turma = await _service.AdicionarAlunoaTurma(idAluno, idTurma);
            if (Turma == null)
            {
                return NotFound();
            }

            return RedirectToAction("ListaAlunosTurma",  new {id = idTurma});
        }

    }
}
