using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseOfShows.WebMVC.Models;

namespace HouseOfShows.WebMVC.Controllers
{
    public class ResponsaveisController : Controller
    {
        private readonly houseofshowsContext _context;

        public ResponsaveisController(houseofshowsContext context)
        {
            _context = context;
        }

        // GET: Responsaveis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responsaveis.ToListAsync());
        }

        // GET: Responsaveis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavei = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (responsavei == null)
            {
                return NotFound();
            }

            return View(responsavei);
        }

        // GET: Responsaveis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Nome,DataNascimento,Cidade,Uf,Endereco")] Responsavei responsavei)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavei);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsavei);
        }

        // GET: Responsaveis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavei = await _context.Responsaveis.FindAsync(id);
            if (responsavei == null)
            {
                return NotFound();
            }
            return View(responsavei);
        }

        // POST: Responsaveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cpf,Nome,DataNascimento,Cidade,Uf,Endereco")] Responsavei responsavei)
        {
            if (id != responsavei.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavei);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsaveiExists(responsavei.Cpf))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(responsavei);
        }

        // GET: Responsaveis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavei = await _context.Responsaveis
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (responsavei == null)
            {
                return NotFound();
            }

            return View(responsavei);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var responsavei = await _context.Responsaveis.FindAsync(id);
            _context.Responsaveis.Remove(responsavei);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsaveiExists(string id)
        {
            return _context.Responsaveis.Any(e => e.Cpf == id);
        }
    }
}
