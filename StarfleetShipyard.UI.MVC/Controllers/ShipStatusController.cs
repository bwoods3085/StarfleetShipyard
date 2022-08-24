using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarfleetShipyard.DATA.EF.Models;

namespace StarfleetShipyard.UI.MVC.Controllers
{
    public class ShipStatusController : Controller
    {
        private readonly StarfleetShipyardContext _context;

        public ShipStatusController(StarfleetShipyardContext context)
        {
            _context = context;
        }

        // GET: ShipStatus
        public async Task<IActionResult> Index()
        {
              return _context.ShipStatuses != null ? 
                          View(await _context.ShipStatuses.ToListAsync()) :
                          Problem("Entity set 'StarfleetShipyardContext.ShipStatuses'  is null.");
        }

        // GET: ShipStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShipStatuses == null)
            {
                return NotFound();
            }

            var shipStatus = await _context.ShipStatuses
                .FirstOrDefaultAsync(m => m.ShipStatusId == id);
            if (shipStatus == null)
            {
                return NotFound();
            }

            return View(shipStatus);
        }

        // GET: ShipStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipStatusId,ShipStatusName")] ShipStatus shipStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipStatus);
        }

        // GET: ShipStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShipStatuses == null)
            {
                return NotFound();
            }

            var shipStatus = await _context.ShipStatuses.FindAsync(id);
            if (shipStatus == null)
            {
                return NotFound();
            }
            return View(shipStatus);
        }

        // POST: ShipStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipStatusId,ShipStatusName")] ShipStatus shipStatus)
        {
            if (id != shipStatus.ShipStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipStatusExists(shipStatus.ShipStatusId))
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
            return View(shipStatus);
        }

        // GET: ShipStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShipStatuses == null)
            {
                return NotFound();
            }

            var shipStatus = await _context.ShipStatuses
                .FirstOrDefaultAsync(m => m.ShipStatusId == id);
            if (shipStatus == null)
            {
                return NotFound();
            }

            return View(shipStatus);
        }

        // POST: ShipStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShipStatuses == null)
            {
                return Problem("Entity set 'StarfleetShipyardContext.ShipStatuses'  is null.");
            }
            var shipStatus = await _context.ShipStatuses.FindAsync(id);
            if (shipStatus != null)
            {
                _context.ShipStatuses.Remove(shipStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipStatusExists(int id)
        {
          return (_context.ShipStatuses?.Any(e => e.ShipStatusId == id)).GetValueOrDefault();
        }
    }
}
