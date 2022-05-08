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
    public class ReservasController : Controller
    {
        private readonly HotelAppContext _context;

        public ReservasController(HotelAppContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var hotelAppContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Quarto).Include(r => r.StatusReserva);
            return View(await hotelAppContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .Include(r => r.StatusReserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["QuartoID"] = new SelectList(_context.Quarto, "Id", "Numero");
            ViewData["StatusReservasID"] = new SelectList(_context.StatusReserva, "StatusReservaID", "Nome");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteID,QuartoID,DataCheckIn,DataCheckOut,StatusReservaID")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "Id", "Nome", reserva.ClienteID);
            ViewData["QuartoID"] = new SelectList(_context.Quarto, "Id", "Numero", reserva.QuartoID);
            ViewData["StatusReservaID"] = new SelectList(_context.StatusReserva, "StatusReservaID", "Nome", reserva.StatusReservaID);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["StatusReservaID"] = new SelectList(_context.StatusReserva, "StatusReservaID", "Nome", reserva.StatusReservaID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "Id", "Nome", reserva.ClienteID);
            ViewData["QuartoID"] = new SelectList(_context.Quarto, "Id", "Numero", reserva.QuartoID);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteID,QuartoID,DataCheckIn,DataCheckOut,StatusReservaID")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["StatusReservaID"] = new SelectList(_context.StatusReserva, "StatusReservaID", "Nome", reserva.StatusReservaID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "Id", "Nome", reserva.ClienteID);
            ViewData["QuartoID"] = new SelectList(_context.Quarto, "Id", "Numero", reserva.QuartoID);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .Include(r => r.StatusReserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
