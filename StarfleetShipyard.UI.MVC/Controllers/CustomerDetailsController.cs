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
    public class CustomerDetailsController : Controller
    {
        private readonly StarfleetShipyardContext _context;

        public CustomerDetailsController(StarfleetShipyardContext context)
        {
            _context = context;
        }

        // GET: CustomerDetails
        public async Task<IActionResult> Index()
        {
              return _context.CustomerDetails != null ? 
                          View(await _context.CustomerDetails.ToListAsync()) :
                          Problem("Entity set 'StarfleetShipyardContext.CustomerDetails'  is null.");
        }

        // GET: CustomerDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CustomerDetails == null)
            {
                return NotFound();
            }

            var customerDetail = await _context.CustomerDetails
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            return View(customerDetail);
        }

        // GET: CustomerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Email,Phone,Address,Shipyard,City,State,Zip,Planet,Sector,Quadrant")] CustomerDetail customerDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDetail);
        }

        // GET: CustomerDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CustomerDetails == null)
            {
                return NotFound();
            }

            var customerDetail = await _context.CustomerDetails.FindAsync(id);
            if (customerDetail == null)
            {
                return NotFound();
            }
            return View(customerDetail);
        }

        // POST: CustomerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,FirstName,LastName,Email,Phone,Address,Shipyard,City,State,Zip,Planet,Sector,Quadrant")] CustomerDetail customerDetail)
        {
            if (id != customerDetail.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerDetailExists(customerDetail.CustomerId))
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
            return View(customerDetail);
        }

        // GET: CustomerDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CustomerDetails == null)
            {
                return NotFound();
            }

            var customerDetail = await _context.CustomerDetails
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerDetail == null)
            {
                return NotFound();
            }

            return View(customerDetail);
        }

        // POST: CustomerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CustomerDetails == null)
            {
                return Problem("Entity set 'StarfleetShipyardContext.CustomerDetails'  is null.");
            }
            var customerDetail = await _context.CustomerDetails.FindAsync(id);
            if (customerDetail != null)
            {
                _context.CustomerDetails.Remove(customerDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerDetailExists(string id)
        {
          return (_context.CustomerDetails?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
