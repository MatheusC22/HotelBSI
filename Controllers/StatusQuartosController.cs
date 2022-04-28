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
    public class StatusQuartosController : Controller
    {
        private readonly HotelAppContext _context;

        public StatusQuartosController(HotelAppContext context)
        {
            _context = context;
        }

        // GET: StatusQuartos
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusQuarto.ToListAsync());
        }

        // GET: StatusQuartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusQuarto = await _context.StatusQuarto
                .FirstOrDefaultAsync(m => m.StatusQuartoID == id);
            if (StatusQuarto == null)
            {
                return NotFound();
            }

            return View(StatusQuarto);
        }

        // GET: StatusQuartos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusQuartos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusQuartoID,Nome,Descricao")] StatusQuarto StatusQuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(StatusQuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(StatusQuarto);
        }

        // GET: StatusQuartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusQuarto = await _context.StatusQuarto.FindAsync(id);
            if (StatusQuarto == null)
            {
                return NotFound();
            }
            return View(StatusQuarto);
        }

        // POST: StatusQuartos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusQuartoID,Nome,Descricao")] StatusQuarto StatusQuarto)
        {
            if (id != StatusQuarto.StatusQuartoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(StatusQuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusQuartoExists(StatusQuarto.StatusQuartoID))
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
            return View(StatusQuarto);
        }

        // GET: StatusQuartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusQuarto = await _context.StatusQuarto
                .FirstOrDefaultAsync(m => m.StatusQuartoID == id);
            if (StatusQuarto == null)
            {
                return NotFound();
            }

            return View(StatusQuarto);
        }

        // POST: StatusQuartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var StatusQuarto = await _context.StatusQuarto.FindAsync(id);
            _context.StatusQuarto.Remove(StatusQuarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusQuartoExists(int id)
        {
            return _context.StatusQuarto.Any(e => e.StatusQuartoID == id);
        }
    }
}
