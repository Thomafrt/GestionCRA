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
        private readonly ILogger<EntriesController> _logger;

        public EntriesController(ApplicationDbContext context, ILogger<EntriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Entries.Include(e => e.Employee).Include(e => e.Mission);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Entries/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email");
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Description");
            ViewBag.EtatOptions = new SelectList(Enum.GetValues(typeof(EtatEntry)));

            return View();
        }

        // POST: Entries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,MissionId,Etat,NumeroSemaine,HeuresLundi,HeuresMardi,HeuresMercredi,HeuresJeudi,HeuresVendredi,HeuresSamedi,HeuresDimanche,DateCreation")] Entry entry)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Charger les entités associées pour le cas où le modèle n'est pas valide
                    entry.Employee = _context.Employees.Find(entry.EmployeeId);
                    entry.Mission = _context.Missions.Find(entry.MissionId);
                    _context.Add(entry);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error saving to database: {0}", ex.Message);
                    throw;
                }
            }

            foreach (var modelStateEntry in ModelState.Values)
            {
                foreach (var error in modelStateEntry.Errors)
                {
                    _logger.LogError("ModelState Error: {0}", error.ErrorMessage);
                }
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Description", entry.MissionId);
            ViewBag.EtatOptions = new SelectList(Enum.GetValues(typeof(EtatEntry)));
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Description", entry.MissionId);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,MissionId,Etat,NumeroSemaine,HeuresLundi,HeuresMardi,HeuresMercredi,HeuresJeudi,HeuresVendredi,HeuresSamedi,HeuresDimanche,DateCreation")] Entry entry)
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Email", entry.EmployeeId);
            ViewData["MissionId"] = new SelectList(_context.Missions, "Id", "Description", entry.MissionId);
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
    }
}
