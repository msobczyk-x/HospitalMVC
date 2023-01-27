using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManager.Data;
using HospitalManager.Models;

namespace HospitalManager.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly HospitalManagerContext _context;

        public DoktorsController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Doktors
        public async Task<IActionResult> Index()
        {
            var hospitalManagerContext = _context.Doktor.Include(d => d.Oddzial);
            return View(await hospitalManagerContext.ToListAsync());
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .Include(d => d.Oddzial)
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            ViewData["OddzialID"] = new SelectList(_context.Oddzial, "OddzialID", "Nazwa");
            return View();
        }

        // POST: Doktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoktorID,Imie,Nazwisko,Specjalizacja,Adres,Telefon,OddzialID")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OddzialID"] = new SelectList(_context.Oddzial, "OddzialID", "Nazwa", doktor.OddzialID);
            return View(doktor);
        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            ViewData["OddzialID"] = new SelectList(_context.Oddzial, "OddzialID", "Nazwa", doktor.OddzialID);
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoktorID,Imie,Nazwisko,Specjalizacja,Adres,Telefon,OddzialID")] Doktor doktor)
        {
            if (id != doktor.DoktorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.DoktorID))
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
            ViewData["OddzialID"] = new SelectList(_context.Oddzial, "OddzialID", "Nazwa", doktor.OddzialID);
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doktor == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktor
                .Include(d => d.Oddzial)
                .FirstOrDefaultAsync(m => m.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doktor == null)
            {
                return Problem("Entity set 'HospitalManagerContext.Doktor'  is null.");
            }
            var doktor = await _context.Doktor.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktor.Remove(doktor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
          return _context.Doktor.Any(e => e.DoktorID == id);
        }
    }
}
