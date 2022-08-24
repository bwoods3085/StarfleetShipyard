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
    public class ShipsController : Controller
    {
        private readonly StarfleetShipyardContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShipsController(StarfleetShipyardContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Ships
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var ships =
                _context.Ships
                .Include(s => s.ShipClasses)
                .Include(s => s.ShipStatus)
                .Include(s => s.ShipTypes)
                .Include(s => s.Supplier);

            if (User.IsInRole("Admin"))
            {
                return View(await ships.ToListAsync());
            }
            else
            {
                return RedirectToAction("TiledProducts");
            }
        }

        // GET: Ships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ships == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .Include(s => s.ShipClasses)
                .Include(s => s.ShipStatus)
                .Include(s => s.ShipTypes)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        [AllowAnonymous]
        public async Task<IActionResult> TiledProducts()
        {
            var ship
        }
        // GET: Ships/Create
        public IActionResult Create()
        {
            ViewData["ShipClassesId"] = new SelectList(_context.ShipClasses, "ShipClassesId", "ShipClassesName");
            ViewData["ShipStatusId"] = new SelectList(_context.ShipStatuses, "ShipStatusId", "ShipStatusName");
            ViewData["ShipTypesId"] = new SelectList(_context.ShipTypes, "ShipTypesId", "ShipTypesName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Planet");
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipId,ShipName,ShipPrice,ShipDescription,UnitsInStock,UnitsOnOrder,ShipStatusId,ShipClassesId,ShipTypesId,SupplierId,ShipImage")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShipClassesId"] = new SelectList(_context.ShipClasses, "ShipClassesId", "ShipClassesName", ship.ShipClassesId);
            ViewData["ShipStatusId"] = new SelectList(_context.ShipStatuses, "ShipStatusId", "ShipStatusName", ship.ShipStatusId);
            ViewData["ShipTypesId"] = new SelectList(_context.ShipTypes, "ShipTypesId", "ShipTypesName", ship.ShipTypesId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Planet", ship.SupplierId);
            return View(ship);
        }

        // GET: Ships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ships == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            ViewData["ShipClassesId"] = new SelectList(_context.ShipClasses, "ShipClassesId", "ShipClassesName", ship.ShipClassesId);
            ViewData["ShipStatusId"] = new SelectList(_context.ShipStatuses, "ShipStatusId", "ShipStatusName", ship.ShipStatusId);
            ViewData["ShipTypesId"] = new SelectList(_context.ShipTypes, "ShipTypesId", "ShipTypesName", ship.ShipTypesId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Planet", ship.SupplierId);
            return View(ship);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipId,ShipName,ShipPrice,ShipDescription,UnitsInStock,UnitsOnOrder,ShipStatusId,ShipClassesId,ShipTypesId,SupplierId,ShipImage")] Ship ship)
        {
            if (id != ship.ShipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.ShipId))
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
            ViewData["ShipClassesId"] = new SelectList(_context.ShipClasses, "ShipClassesId", "ShipClassesName", ship.ShipClassesId);
            ViewData["ShipStatusId"] = new SelectList(_context.ShipStatuses, "ShipStatusId", "ShipStatusName", ship.ShipStatusId);
            ViewData["ShipTypesId"] = new SelectList(_context.ShipTypes, "ShipTypesId", "ShipTypesName", ship.ShipTypesId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "Planet", ship.SupplierId);
            return View(ship);
        }

        // GET: Ships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ships == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .Include(s => s.ShipClasses)
                .Include(s => s.ShipStatus)
                .Include(s => s.ShipTypes)
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.ShipId == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ships == null)
            {
                return Problem("Entity set 'StarfleetShipyardContext.Ships'  is null.");
            }
            var ship = await _context.Ships.FindAsync(id);
            if (ship != null)
            {
                _context.Ships.Remove(ship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(int id)
        {
          return (_context.Ships?.Any(e => e.ShipId == id)).GetValueOrDefault();
        }
    }
}
