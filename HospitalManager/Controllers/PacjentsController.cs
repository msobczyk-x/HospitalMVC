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
	[Authorize(Roles = "Admin")]
	public class PacjentsController : Controller
    {
        private readonly HospitalManagerContext _context;

        public PacjentsController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Pacjents
        public async Task<IActionResult> Index(string searchString, bool notUsed)


        {

	        if (_context.Pacjent == null)
	        {
		        return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
	        }

	        var pacjenci = from m in _context.Pacjent
		        select m;

	        if (!String.IsNullOrEmpty(searchString))
	        {
		        pacjenci = pacjenci.Where(s => s.Nazwisko!.Contains(searchString));
	        }


			return View(await pacjenci.ToListAsync());
        }


		// GET: Pacjents/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacjent == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjent
                .FirstOrDefaultAsync(m => m.PacjentID == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // GET: Pacjents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacjents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacjentID,Imie,Nazwisko,PESEL,Adres,Telefon")] Pacjent pacjent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacjent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacjent);
        }

        // GET: Pacjents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacjent == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjent.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }
            return View(pacjent);
        }

        // POST: Pacjents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacjentID,Imie,Nazwisko,PESEL,Adres,Telefon")] Pacjent pacjent)
        {
            if (id != pacjent.PacjentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacjent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacjentExists(pacjent.PacjentID))
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
            return View(pacjent);
        }

        // GET: Pacjents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacjent == null)
            {
                return NotFound();
            }

            var pacjent = await _context.Pacjent
                .FirstOrDefaultAsync(m => m.PacjentID == id);
            if (pacjent == null)
            {
                return NotFound();
            }

            return View(pacjent);
        }

        // POST: Pacjents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacjent == null)
            {
                return Problem("Entity set 'HospitalManagerContext.Pacjent'  is null.");
            }
            var pacjent = await _context.Pacjent.FindAsync(id);
            if (pacjent != null)
            {
                _context.Pacjent.Remove(pacjent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacjentExists(int id)
        {
          return _context.Pacjent.Any(e => e.PacjentID == id);
        }
    }
}
