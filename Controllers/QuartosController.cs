using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp.Models;

namespace HotelApp.Controllers
{
    public class QuartosController : Controller
    {
        private readonly HotelAppContext _context;

        public QuartosController(HotelAppContext context)
        {
            _context = context;
        }

        // GET: Quartos
        public async Task<IActionResult> Index()
        {
            var HotelAppContext = _context.Quarto
                .Include(r => r.TipoQuarto).Include(r => r.StatusQuarto);
            return View(await HotelAppContext.ToListAsync());
        }

        // GET: Quartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto
                .Include(r => r.TipoQuarto)
                .Include(r => r.StatusQuarto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // GET: Quartos/Create
        public IActionResult Create()
        {
            ViewData["TipoQuartosID"] = new SelectList(_context.TipoQuarto, "TipoQuartoID","Nome");
            ViewData["StatusQuartosID"] = new SelectList(_context.StatusQuarto, "StatusQuartoID","Nome");
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Descricao,TipoQuartoID,Localizacao,StatusQuartoID")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto.FindAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }
            ViewData["TipoQuartosID"] = new SelectList(_context.TipoQuarto, "TipoQuartoID","Nome");
            ViewData["StatusQuartosID"] = new SelectList(_context.StatusQuarto, "StatusQuartoID","Nome");
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Descricao,TipoQuartoID,Localizacao,StatusQuartoID")] Quarto quarto)
        {
            if (id != quarto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuartoExists(quarto.Id))
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
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _context.Quarto
                .Include(r => r.TipoQuarto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quarto = await _context.Quarto.FindAsync(id);
            _context.Quarto.Remove(quarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuartoExists(int id)
        {
            return _context.Quarto.Any(e => e.Id == id);
        }
    }
}
