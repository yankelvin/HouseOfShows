using HouseOfShows.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HouseOfShows.WebMVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly houseofshowsContext _context;

        public VendasController(houseofshowsContext context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var houseofshowsContext = _context.Vendas.Include(v => v.CpfClienteNavigation).Include(v => v.IdEventoNavigation).Include(v => v.TipoIngressoNavigation);
            return View(await houseofshowsContext.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.CpfClienteNavigation)
                .Include(v => v.IdEventoNavigation)
                .Include(v => v.TipoIngressoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["CpfCliente"] = new SelectList(_context.Clientes, "Cpf", "Cpf");
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "CpfResponsavel");
            ViewData["TipoIngresso"] = new SelectList(_context.TipoIngressos, "TipoIngresso1", "TipoIngresso1");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdEvento,CpfCliente,TipoIngresso,QtdIngresso")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                var evento = await _context.Eventos.FirstOrDefaultAsync(evento => evento.Id.Equals(venda.IdEvento));
                venda.ValorTotal = venda.QtdIngresso * (venda.TipoIngresso == "Inteira" ? evento.ValorInteira : evento.ValorMeia);

                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CpfCliente"] = new SelectList(_context.Clientes, "Cpf", "Cpf", venda.CpfCliente);
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "CpfResponsavel", venda.IdEvento);
            ViewData["TipoIngresso"] = new SelectList(_context.TipoIngressos, "TipoIngresso1", "TipoIngresso1", venda.TipoIngresso);

            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            ViewData["CpfCliente"] = new SelectList(_context.Clientes, "Cpf", "Cpf", venda.CpfCliente);
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "CpfResponsavel", venda.IdEvento);
            ViewData["TipoIngresso"] = new SelectList(_context.TipoIngressos, "TipoIngresso1", "TipoIngresso1", venda.TipoIngresso);

            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdEvento,CpfCliente,TipoIngresso,QtdIngresso")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
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
            ViewData["CpfCliente"] = new SelectList(_context.Clientes, "Cpf", "Cpf", venda.CpfCliente);
            ViewData["IdEvento"] = new SelectList(_context.Eventos, "Id", "CpfResponsavel", venda.IdEvento);
            ViewData["TipoIngresso"] = new SelectList(_context.TipoIngressos, "TipoIngresso1", "TipoIngresso1", venda.TipoIngresso);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.CpfClienteNavigation)
                .Include(v => v.IdEventoNavigation)
                .Include(v => v.TipoIngressoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.IdVenda == id);
        }
    }
}
