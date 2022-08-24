using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarfleetShipyard.DATA.EF.Models;

namespace StarfleetShipyard.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShipClassesController : Controller
    {
        private readonly StarfleetShipyardContext _context;

        public ShipClassesController(StarfleetShipyardContext context)
        {
            _context = context;
        }

        // GET: ShipClasses
        public async Task<IActionResult> Index()
        {
              return _context.ShipClasses != null ? 
                          View(await _context.ShipClasses.ToListAsync()) :
                          Problem("Entity set 'StarfleetShipyardContext.ShipClasses'  is null.");
        }

        // GET: ShipClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShipClasses == null)
            {
                return NotFound();
            }

            var shipClass = await _context.ShipClasses
                .FirstOrDefaultAsync(m => m.ShipClassesId == id);
            if (shipClass == null)
            {
                return NotFound();
            }

            return View(shipClass);
        }

        // GET: ShipClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipClassesId,ShipClassesName,ShipClassesDescription")] ShipClass shipClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipClass);
        }

        // GET: ShipClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShipClasses == null)
            {
                return NotFound();
            }

            var shipClass = await _context.ShipClasses.FindAsync(id);
            if (shipClass == null)
            {
                return NotFound();
            }
            return View(shipClass);
        }

        // POST: ShipClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipClassesId,ShipClassesName,ShipClassesDescription")] ShipClass shipClass)
        {
            if (id != shipClass.ShipClassesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipClassExists(shipClass.ShipClassesId))
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
            return View(shipClass);
        }

        // GET: ShipClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShipClasses == null)
            {
                return NotFound();
            }

            var shipClass = await _context.ShipClasses
                .FirstOrDefaultAsync(m => m.ShipClassesId == id);
            if (shipClass == null)
            {
                return NotFound();
            }

            return View(shipClass);
        }

        // POST: ShipClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShipClasses == null)
            {
                return Problem("Entity set 'StarfleetShipyardContext.ShipClasses'  is null.");
            }
            var shipClass = await _context.ShipClasses.FindAsync(id);
            if (shipClass != null)
            {
                _context.ShipClasses.Remove(shipClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipClassExists(int id)
        {
          return (_context.ShipClasses?.Any(e => e.ShipClassesId == id)).GetValueOrDefault();
        }
    }
}
