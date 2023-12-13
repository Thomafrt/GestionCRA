using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRA.Models;
using GestionCRA.Data;

namespace GestionCRA.Controllers
{
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entries.Include(e => e.Employee).Include(e => e.Mission);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult Submit(int id)
        {
            Entry entry = _context.Entries.Find(id);

            if (entry == null)
            {
                return NotFound(); // Entrée non trouvée, renvoyer une vue appropriée ou une erreur.
            }

            entry.State = EntryState.Soumis;
            _context.SaveChanges(); // Sauvegarder les modifications dans la base de données

            return RedirectToAction(nameof(Index));
        }


        // GET: Entries/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Nom");
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Nom");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MissionId,EmployeeId,State,Week,SundayHours,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours,SaturdayHours")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Nom", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Nom", entry.MissionId);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entries == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Nom", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Nom", entry.MissionId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MissionId,EmployeeId,State,Week,SundayHours,MondayHours,TuesdayHours,WednesdayHours,ThursdayHours,FridayHours,SaturdayHours")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Nom", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Nom", entry.MissionId);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entries == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .Include(e => e.Employee)
                .Include(e => e.Mission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Entries'  is null.");
            }
            var entry = await _context.Entries.FindAsync(id);
            if (entry != null)
            {
                _context.Entries.Remove(entry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
          return (_context.Entries?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        public async Task<IActionResult> ValidateEntry()
        {
            var soumisEntries = await _context.Entries
                .Include(e => e.Employee)
                .Include(e => e.Mission)
                .Where(e => e.State == EntryState.Soumis)
                .ToListAsync();

            return View(soumisEntries);
        }
        [HttpPost]
        public IActionResult Refuse(int id)
        {
            var entry = _context.Entries.Find(id);

            if (entry == null)
            {
                return NotFound();
            }

            entry.State = CRA.Models.EntryState.Refuse;
            _context.SaveChanges();

            return RedirectToAction("ValidateEntry");
        }

        [HttpPost]
        public IActionResult Validate(int id)
        {
            var entry = _context.Entries.Find(id);

            if (entry == null)
            {
                return NotFound();
            }

            entry.State = CRA.Models.EntryState.Valide;
            _context.SaveChanges();

            return RedirectToAction("ValidateEntry");
        }

    }
}
