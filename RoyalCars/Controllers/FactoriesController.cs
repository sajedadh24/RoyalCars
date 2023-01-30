using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;

namespace RoyalCars.Controllers
{
    public class FactoriesController : Controller
    {
        private readonly RoyalDbContext _context;

        public FactoriesController(RoyalDbContext context)
        {
            _context = context;
        }

        // GET: Factories
        public async Task<IActionResult> Index()
        {
            var royalDbContext = _context.Factories;
            return View(await royalDbContext.ToListAsync());
        }

        // GET: Factories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories
                .FirstOrDefaultAsync(m => m.FactoryId == id);
            if (factory == null)
            {
                return NotFound();
            }

            return View(factory);
        }

        // GET: Factories/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
            return View();
        }

        // POST: Factories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Factory factory)
        {
            if (ModelState.IsValid)
            {
                Factory fa = new Factory
                {
                    FactoryName=factory.FactoryName
                 
                    
                };
                _context.Add(factory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factory);
        }

        // GET: Factories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories.FindAsync(id);
            if (factory == null)
            {
                return NotFound();
            }
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", factory.CompanyId);
            return View(factory);
        }

        // POST: Factories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FactoryId,FactoryName,CompanyId")] Factory factory)
        {
            if (id != factory.FactoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactoryExists(factory.FactoryId))
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
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId", factory.CompanyId);
            return View(factory);
        }

        // GET: Factories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factory = await _context.Factories
                .FirstOrDefaultAsync(m => m.FactoryId == id);
            if (factory == null)
            {
                return NotFound();
            }

            return View(factory);
        }

        // POST: Factories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factory = await _context.Factories.FindAsync(id);
            _context.Factories.Remove(factory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactoryExists(int id)
        {
            return _context.Factories.Any(e => e.FactoryId == id);
        }
    }
}
