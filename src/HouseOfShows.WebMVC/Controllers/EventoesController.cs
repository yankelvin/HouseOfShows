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
    public class EventoesController : Controller
    {
        private readonly houseofshowsContext _context;

        public EventoesController(houseofshowsContext context)
        {
            _context = context;
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            var houseofshowsContext = _context.Eventos.Include(e => e.CpfResponsavelNavigation).Include(e => e.NomeStatusNavigation);
            return View(await houseofshowsContext.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.CpfResponsavelNavigation)
                .Include(e => e.NomeStatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Create
        public IActionResult Create()
        {
            ViewData["CpfResponsavel"] = new SelectList(_context.Responsaveis, "Cpf", "Cpf");
            ViewData["NomeStatus"] = new SelectList(_context.Statuses, "NomeStatus", "NomeStatus");
            return View();
        }

        // POST: Eventoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataEvento,CpfResponsavel,ValorInteira,ValorMeia,NomeStatus")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CpfResponsavel"] = new SelectList(_context.Responsaveis, "Cpf", "Cpf", evento.CpfResponsavel);
            ViewData["NomeStatus"] = new SelectList(_context.Statuses, "NomeStatus", "NomeStatus", evento.NomeStatus);
            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["CpfResponsavel"] = new SelectList(_context.Responsaveis, "Cpf", "Cpf", evento.CpfResponsavel);
            ViewData["NomeStatus"] = new SelectList(_context.Statuses, "NomeStatus", "NomeStatus", evento.NomeStatus);
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataEvento,CpfResponsavel,ValorInteira,ValorMeia,NomeStatus")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            ViewData["CpfResponsavel"] = new SelectList(_context.Responsaveis, "Cpf", "Cpf", evento.CpfResponsavel);
            ViewData["NomeStatus"] = new SelectList(_context.Statuses, "NomeStatus", "NomeStatus", evento.NomeStatus);
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.CpfResponsavelNavigation)
                .Include(e => e.NomeStatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
