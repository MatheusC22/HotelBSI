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
    public class StatusReservasController : Controller
    {
        private readonly HotelAppContext _context;

        public StatusReservasController(HotelAppContext context)
        {
            _context = context;
        }

        // GET: StatusReservas
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusReserva.ToListAsync());
        }

        // GET: StatusReservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusReserva = await _context.StatusReserva
                .FirstOrDefaultAsync(m => m.StatusReservaID == id);
            if (StatusReserva == null)
            {
                return NotFound();
            }

            return View(StatusReserva);
        }

        // GET: StatusReservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusReservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusReservaID,Nome,Descricao")] StatusReserva StatusReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(StatusReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(StatusReserva);
        }

        // GET: StatusReservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusReserva = await _context.StatusReserva.FindAsync(id);
            if (StatusReserva == null)
            {
                return NotFound();
            }
            return View(StatusReserva);
        }

        // POST: StatusReservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusReservaID,Nome,Descricao")] StatusReserva StatusReserva)
        {
            if (id != StatusReserva.StatusReservaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(StatusReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusReservaExists(StatusReserva.StatusReservaID))
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
            return View(StatusReserva);
        }

        // GET: StatusReservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var StatusReserva = await _context.StatusReserva
                .FirstOrDefaultAsync(m => m.StatusReservaID == id);
            if (StatusReserva == null)
            {
                return NotFound();
            }

            return View(StatusReserva);
        }

        // POST: StatusReservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var StatusReserva = await _context.StatusReserva.FindAsync(id);
            _context.StatusReserva.Remove(StatusReserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusReservaExists(int id)
        {
            return _context.StatusReserva.Any(e => e.StatusReservaID == id);
        }
    }
}
