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
    public class TipoIngressoesController : Controller
    {
        private readonly houseofshowsContext _context;

        public TipoIngressoesController(houseofshowsContext context)
        {
            _context = context;
        }

        // GET: TipoIngressoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIngressos.ToListAsync());
        }

        // GET: TipoIngressoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngresso = await _context.TipoIngressos
                .FirstOrDefaultAsync(m => m.TipoIngresso1 == id);
            if (tipoIngresso == null)
            {
                return NotFound();
            }

            return View(tipoIngresso);
        }

        // GET: TipoIngressoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIngressoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoIngresso1")] TipoIngresso tipoIngresso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIngresso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIngresso);
        }

        // GET: TipoIngressoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngresso = await _context.TipoIngressos.FindAsync(id);
            if (tipoIngresso == null)
            {
                return NotFound();
            }
            return View(tipoIngresso);
        }

        // POST: TipoIngressoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoIngresso1")] TipoIngresso tipoIngresso)
        {
            if (id != tipoIngresso.TipoIngresso1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIngresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIngressoExists(tipoIngresso.TipoIngresso1))
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
            return View(tipoIngresso);
        }

        // GET: TipoIngressoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngresso = await _context.TipoIngressos
                .FirstOrDefaultAsync(m => m.TipoIngresso1 == id);
            if (tipoIngresso == null)
            {
                return NotFound();
            }

            return View(tipoIngresso);
        }

        // POST: TipoIngressoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoIngresso = await _context.TipoIngressos.FindAsync(id);
            _context.TipoIngressos.Remove(tipoIngresso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIngressoExists(string id)
        {
            return _context.TipoIngressos.Any(e => e.TipoIngresso1 == id);
        }
    }
}
