﻿using System;
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
    public class MissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Missions
        public async Task<IActionResult> Index()
        {
            if (_context.Missions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Missions' is null.");
            }

            // Charger les employés liés lors de la récupération des missions
            var missions = await _context.Missions
                .Include(m => m.Employees) // Charger les employés liés
                .ToListAsync();

            return View(missions);
        }


        // GET: Missions/Create
        public IActionResult Create()
        {
            // Charger la liste des employés pour la vue
            ViewBag.EmployeeList = new MultiSelectList(_context.Employees, "Id", "Nom");
            return View();
        }


        // POST: Missions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Description,SemaineDebut,SemaineFin,EmployeeIds")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                // Charger les employés sélectionnés
                mission.Employees = await _context.Employees
                    .Where(e => mission.EmployeeIds.Contains(e.Id))
                    .ToListAsync();

                _context.Add(mission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Recharger la liste des employés pour la vue
            ViewBag.EmployeeList = new SelectList(_context.Employees, "Id", "Nom", mission.EmployeeIds);
            return View(mission);
        }


        // GET: Missions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions
                .Include(m => m.Employees)  // Inclure la liste des employés associés à la mission
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mission == null)
            {
                return NotFound();
            }

            // Charger la liste des employés pour la vue
            ViewBag.EmployeeList = new MultiSelectList(_context.Employees, "Id", "Nom", mission.EmployeeIds);

            return View(mission);
        }


        // POST: Missions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Description,SemaineDebut,SemaineFin,EmployeeIds")] Mission mission)
        {
            if (id != mission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Charger la mission depuis la base de données avec les employés associés
                    var existingMission = await _context.Missions
                        .Include(m => m.Employees)
                        .FirstOrDefaultAsync(m => m.Id == id);

                    if (existingMission == null)
                    {
                        return NotFound();
                    }

                    // Mettre à jour les propriétés de la mission
                    existingMission.Nom = mission.Nom;
                    existingMission.Description = mission.Description;
                    existingMission.SemaineDebut = mission.SemaineDebut;
                    existingMission.SemaineFin = mission.SemaineFin;

                    // Charger les employés sélectionnés
                    existingMission.Employees = await _context.Employees
                        .Where(e => mission.EmployeeIds.Contains(e.Id))
                        .ToListAsync();

                    _context.Update(existingMission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissionExists(mission.Id))
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

            // Si la validation a échoué, rechargez la liste des employés pour la vue
            ViewBag.EmployeeList = new MultiSelectList(_context.Employees, "Id", "Nom", mission.EmployeeIds);
            return View(mission);
        }



        // GET: Missions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Missions == null)
            {
                return NotFound();
            }

            var mission = await _context.Missions
                .Include(m => m.Employees)  // Charger les employés associés à la mission
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mission == null)
            {
                return NotFound();
            }

            return View(mission);
        }

        // POST: Missions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Missions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Missions'  is null.");
            }
            var mission = await _context.Missions.FindAsync(id);
            if (mission != null)
            {
                _context.Missions.Remove(mission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissionExists(int id)
        {
          return (_context.Missions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
