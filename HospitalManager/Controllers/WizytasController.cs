using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManager.Data;
using HospitalManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManager.Controllers
{
    public class WizytasController : Controller
    {
        private readonly HospitalManagerContext _context;

        public WizytasController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Wizytas
        public async Task<IActionResult> Index(string searchString, bool notUsed)


        {
         

            
            var hospitalManagerContext = _context.Wizyta.Include(w => w.Doktor).Include(w => w.Pacjent);
            
            return View(await hospitalManagerContext.ToListAsync());
        }

        // GET: Wizytas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wizyta == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyta
                .Include(w => w.Doktor)
                .Include(w => w.Pacjent)
                .FirstOrDefaultAsync(m => m.WizytaID == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

		// GET: Wizytas/Create
		[Authorize(Roles = "Admin")]
		public IActionResult Create()
        {
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "ImieNazwisko");
            ViewData["PacjentID"] = new SelectList(_context.Pacjent, "PacjentID", "ImieNazwisko");
            return View();
        }

        // POST: Wizytas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
		public async Task<IActionResult> Create([Bind("WizytaID,DoktorID,PacjentID,Data,Opis")] Wizyta wizyta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wizyta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "ImieNazwisko", wizyta.DoktorID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjent, "PacjentID", "ImieNazwisko", wizyta.PacjentID);
            return View(wizyta);
        }

		// GET: Wizytas/Edit/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wizyta == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyta.FindAsync(id);
            if (wizyta == null)
            {
                return NotFound();
            }
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "ImieNazwisko", wizyta.DoktorID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjent, "PacjentID", "ImieNazwisko", wizyta.PacjentID);
            return View(wizyta);
        }

        // POST: Wizytas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(int id, [Bind("WizytaID,DoktorID,PacjentID,Data,Opis")] Wizyta wizyta)
        {
            if (id != wizyta.WizytaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wizyta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WizytaExists(wizyta.WizytaID))
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
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "ImieNazwisko", wizyta.DoktorID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjent, "PacjentID", "ImieNazwisko", wizyta.PacjentID);
            return View(wizyta);
        }

		// GET: Wizytas/Delete/5
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wizyta == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyta
                .Include(w => w.Doktor)
                .Include(w => w.Pacjent)
                .FirstOrDefaultAsync(m => m.WizytaID == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

		// POST: Wizytas/Delete/5
		[Authorize(Roles = "Admin")]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wizyta == null)
            {
                return Problem("Entity set 'HospitalManagerContext.Wizyta'  is null.");
            }
            var wizyta = await _context.Wizyta.FindAsync(id);
            if (wizyta != null)
            {
                _context.Wizyta.Remove(wizyta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WizytaExists(int id)
        {
          return _context.Wizyta.Any(e => e.WizytaID == id);
        }
    }
}
