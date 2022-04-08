using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;

namespace WebApp.Controllers
{
    public class RentsController : Controller
    {
        private readonly RentACarDbContext _context;

        public RentsController(RentACarDbContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rents.ToListAsync());
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rents == null)
            {
                return NotFound();
            }

            return View(rents);
        }
        public IActionResult DateSelect(DateTime startDate, DateTime endDate)
        {

            return RedirectToAction(nameof(Index));
        }

        // GET: Rents/Create
        public IActionResult Create(int id)
        {
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,CarId,StartDate,EndDate,UserId")] Rents rents)
        {
            if (ModelState.IsValid)
            {
                var car = _context.Cars.FirstOrDefault(car => car.Id == rents.CarId);
                rents.Car = car;
                _context.Add(rents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rents);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents.FindAsync(id);
            if (rents == null)
            {
                return NotFound();
            }
            return View(rents);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,StartDate,EndDate,UserId")] Rents rents)
        {
            if (id != rents.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentsExists(rents.Id))
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
            return View(rents);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rents = await _context.Rents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rents == null)
            {
                return NotFound();
            }

            return View(rents);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rents = await _context.Rents.FindAsync(id);
            _context.Rents.Remove(rents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentsExists(int id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
        public bool CarIsAvailable(int carId, DateTime startDate, DateTime endDate)
        {
            var rents = _context.Rents.Where(x => x.Car.Id == carId);
            if (rents != null)
            {
                foreach (var item in rents)
                {
                    return !(item.StartDate < endDate && startDate < item.EndDate);
                }
                return false;
            }
            else return true;
        }
    }
}
