using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using p9.Data;
using p9.Data.Migrations;
using p9.Models;

namespace p9.Controllers
{
    public class ReparationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReparationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reparations
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reparations.Include(r => r.Voiture);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reparations/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparations
                .Include(r => r.Voiture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }
        [Authorize (Roles= "Admin")]
        // GET: Reparations/Create
                public IActionResult Create()
        {
            var typeInterv = new List<string>
    {

        "Selectionner un type de réparation",
        "Climatisation",
        "Moteur",
        "Carrosserie",
        "frein",
        "allumage",
        "Pneu",
    };

            ViewBag.TypeInterventions= new SelectList(typeInterv);

            var voitures = _context.Voitures.ToList();
            var selectList = new SelectList(voitures, "Id", "MarqueModeleFinition", "Modele");
            ViewBag.VoituresList = selectList;

            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "MarqueModeleFinition");
            return View();
        }

        // POST: Reparations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateReparation,TypeIntervention,CoutReparation,VoitureId")] Reparation reparation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Finition", reparation.VoitureId);
            return View(reparation);
        }

        // GET: Reparations/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparations.FindAsync(id);
            if (reparation == null)
            {
                return NotFound();
            }
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Finition", reparation.VoitureId);
            return View(reparation);
        }

        // POST: Reparations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateReparation,TypeIntervention,CoutReparation,VoitureId")] Reparation reparation)
        {
            if (id != reparation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparationExists(reparation.Id))
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
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "Id", "Finition", reparation.VoitureId);
            return View(reparation);
        }
        [Authorize(Roles = "Admin")]
        // GET: Reparations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reparations == null)
            {
                return NotFound();
            }

            var reparation = await _context.Reparations
                .Include(r => r.Voiture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reparation == null)
            {
                return NotFound();
            }

            return View(reparation);
        }
        [Authorize(Roles = "Admin")]
        // POST: Reparations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reparations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reparations'  is null.");
            }
            var reparation = await _context.Reparations.FindAsync(id);
            if (reparation != null)
            {
                _context.Reparations.Remove(reparation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReparationExists(int id)
        {
          return (_context.Reparations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
