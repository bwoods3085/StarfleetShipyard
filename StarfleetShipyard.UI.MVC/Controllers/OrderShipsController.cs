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
    public class OrderShipsController : Controller
    {
        private readonly StarfleetShipyardContext _context;

        public OrderShipsController(StarfleetShipyardContext context)
        {
            _context = context;
        }

        // GET: OrderShips
        public async Task<IActionResult> Index()
        {
            var StarfleetShipyardContext = _context.OrderShips.Include(o => o.Order).Include(o => o.Ship);
            return View(await StarfleetShipyardContext.ToListAsync());
        }

        // GET: OrderShips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderShips == null)
            {
                return NotFound();
            }

            var orderShip = await _context.OrderShips
                .Include(o => o.Order)
                .Include(o => o.Ship)
                .FirstOrDefaultAsync(m => m.OrderShipsId == id);
            if (orderShip == null)
            {
                return NotFound();
            }

            return View(orderShip);
        }

        // GET: OrderShips/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "CustomerId");
            ViewData["ShipId"] = new SelectList(_context.Ships, "ShipId", "ShipName");
            return View();
        }

        // POST: OrderShips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderShipsId,ShipId,OrderId,Quantity,ShipPrice")] OrderShip orderShip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderShip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "CustomerId", orderShip.OrderId);
            ViewData["ShipId"] = new SelectList(_context.Ships, "ShipId", "ShipName", orderShip.ShipId);
            return View(orderShip);
        }

        // GET: OrderShips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderShips == null)
            {
                return NotFound();
            }

            var orderShip = await _context.OrderShips.FindAsync(id);
            if (orderShip == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "CustomerId", orderShip.OrderId);
            ViewData["ShipId"] = new SelectList(_context.Ships, "ShipId", "ShipName", orderShip.ShipId);
            return View(orderShip);
        }

        // POST: OrderShips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderShipsId,ShipId,OrderId,Quantity,ShipPrice")] OrderShip orderShip)
        {
            if (id != orderShip.OrderShipsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderShip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderShipExists(orderShip.OrderShipsId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "CustomerId", orderShip.OrderId);
            ViewData["ShipId"] = new SelectList(_context.Ships, "ShipId", "ShipName", orderShip.ShipId);
            return View(orderShip);
        }

        // GET: OrderShips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderShips == null)
            {
                return NotFound();
            }

            var orderShip = await _context.OrderShips
                .Include(o => o.Order)
                .Include(o => o.Ship)
                .FirstOrDefaultAsync(m => m.OrderShipsId == id);
            if (orderShip == null)
            {
                return NotFound();
            }

            return View(orderShip);
        }

        // POST: OrderShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderShips == null)
            {
                return Problem("Entity set 'StarfleetShipyardContext.OrderShips'  is null.");
            }
            var orderShip = await _context.OrderShips.FindAsync(id);
            if (orderShip != null)
            {
                _context.OrderShips.Remove(orderShip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderShipExists(int id)
        {
          return (_context.OrderShips?.Any(e => e.OrderShipsId == id)).GetValueOrDefault();
        }
    }
}
