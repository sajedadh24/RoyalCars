
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;

namespace RoyalCars.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservesController : Controller
    {
        private readonly RoyalDbContext _context;

        public ReservesController(RoyalDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Reserves
        public async Task<IActionResult> Index()
        {
            var royalDbContext = _context.Reserves.Include(r => r.Car);
            return View(await royalDbContext.ToListAsync());
        }

        // GET: Admin/Reserves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.ReserveId == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // GET: Admin/Reserves/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId");
            return View();
        }

        // POST: Admin/Reserves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveId,FirstName,Lastame,Email,MobileNumber,Pickuplocation,Droplocation,Payment,SpecialRequest,UserId,IsActive,IsDeleted,CarId,CompanyId,StartDate,StartTime,EndtDate,EndTime")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", reserve.CarId);
            return View(reserve);
        }

        // GET: Admin/Reserves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", reserve.CarId);
            return View(reserve);
        }

        // POST: Admin/Reserves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveId,FirstName,Lastame,Email,MobileNumber,Pickuplocation,Droplocation,Payment,SpecialRequest,UserId,IsActive,IsDeleted,CarId,CompanyId,StartDate,StartTime,EndtDate,EndTime")] Reserve reserve)
        {
            if (id != reserve.ReserveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveExists(reserve.ReserveId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "CarId", reserve.CarId);
            return View(reserve);
        }

        // GET: Admin/Reserves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserves
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.ReserveId == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // POST: Admin/Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            _context.Reserves.Remove(reserve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveExists(int id)
        {
            return _context.Reserves.Any(e => e.ReserveId == id);
        }
    }
}
