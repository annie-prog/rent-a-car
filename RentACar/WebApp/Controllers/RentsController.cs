using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Text;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rents.ToListAsync());
        }

        // GET: Rents/Details/5
        [Authorize]
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

        // GET: Rents/Create
        [Authorize]
        public IActionResult Create(int id)
        {
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Rents rents)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (CarIsAvailable(rents.CarId, rents.StartDate, rents.EndDate))
                    {
                        var car = _context.Cars.FirstOrDefault(car => car.Id == rents.CarId);
                        rents.Car = car;
                        var user = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name);
                        rents.User = user;
                        _context.Add(rents);
                    }
                    else throw new ArgumentException("Selected car is unavailable at the chosen times.");
                    await _context.SaveChangesAsync();
                }
                catch (ArgumentException e)
                {
                    byte[] data = Encoding.UTF8.GetBytes(e.Message + " <a href=\"javascript:history.back()\">Back</a>");
                    Response.ContentType = "text/html";
                    await Response.Body.WriteAsync(data, 0, data.Length);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rents);
        }

        // GET: Rents/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Rents rents)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (CarIsAvailable(rents.CarId, rents.StartDate, rents.EndDate))
                    {
                        _context.Update(rents);
                        await _context.SaveChangesAsync();
                    }
                    else throw new ArgumentException("Selected car is unavailable at the chosen times.");
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
                catch (ArgumentException ex)
                {
                    byte[] data = Encoding.UTF8.GetBytes(ex.Message + " <a href=\"javascript:history.back()\">Back</a>");
                    Response.ContentType = "text/html";
                    await Response.Body.WriteAsync(data, 0, data.Length);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rents);
        }

        // GET: Rents/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
            var rents = _context.Rents.Where(x => x.CarId == carId);
            foreach (var item in rents)
            {
                if (item.StartDate > item.EndDate)
                    throw new ArgumentException("A start can not be after its end.");

                if (startDate > endDate)
                    throw new ArgumentException("B start can not be after its end.");

                if (!((item.EndDate < startDate && item.StartDate < startDate) ||
                            (endDate < item.StartDate && startDate < item.StartDate)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
