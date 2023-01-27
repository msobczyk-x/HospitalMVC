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
	public class OddzialsController : Controller
    {
        private readonly HospitalManagerContext _context;

        public OddzialsController(HospitalManagerContext context)
        {
            _context = context;
        }

        // GET: Oddzials
        public async Task<IActionResult> Index()
        {
              return View(await _context.Oddzial.ToListAsync());
        }

        // GET: Oddzials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oddzial == null)
            {
                return NotFound();
            }

            var oddzial = await _context.Oddzial
                .FirstOrDefaultAsync(m => m.OddzialID == id);
            if (oddzial == null)
            {
                return NotFound();
            }

            return View(oddzial);
        }

        // GET: Oddzials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oddzials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OddzialID,Nazwa,Opis")] Oddzial oddzial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oddzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oddzial);
        }

        // GET: Oddzials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oddzial == null)
            {
                return NotFound();
            }

            var oddzial = await _context.Oddzial.FindAsync(id);
            if (oddzial == null)
            {
                return NotFound();
            }
            return View(oddzial);
        }

        // POST: Oddzials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OddzialID,Nazwa,Opis")] Oddzial oddzial)
        {
            if (id != oddzial.OddzialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oddzial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OddzialExists(oddzial.OddzialID))
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
            return View(oddzial);
        }

        // GET: Oddzials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oddzial == null)
            {
                return NotFound();
            }

            var oddzial = await _context.Oddzial
                .FirstOrDefaultAsync(m => m.OddzialID == id);
            if (oddzial == null)
            {
                return NotFound();
            }

            return View(oddzial);
        }

        // POST: Oddzials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oddzial == null)
            {
                return Problem("Entity set 'HospitalManagerContext.Oddzial'  is null.");
            }
            var oddzial = await _context.Oddzial.FindAsync(id);
            if (oddzial != null)
            {
                _context.Oddzial.Remove(oddzial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OddzialExists(int id)
        {
          return _context.Oddzial.Any(e => e.OddzialID == id);
        }
    }
}
