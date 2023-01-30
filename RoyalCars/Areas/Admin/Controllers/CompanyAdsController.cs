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
    public class CompanyAdsController : Controller
    {
        private readonly RoyalDbContext _context;

        public CompanyAdsController(RoyalDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CompanyAds
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyAds.ToListAsync());
        }

        // GET: Admin/CompanyAds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAd = await _context.CompanyAds
                .FirstOrDefaultAsync(m => m.CompanyAdId == id);
            if (companyAd == null)
            {
                return NotFound();
            }

            return View(companyAd);
        }

        // GET: Admin/CompanyAds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CompanyAds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyAdId,AdTitle,AdSubTitle,AdDescribe,CompanyId")] CompanyAd companyAd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyAd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyAd);
        }

        // GET: Admin/CompanyAds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAd = await _context.CompanyAds.FindAsync(id);
            if (companyAd == null)
            {
                return NotFound();
            }
            return View(companyAd);
        }

        // POST: Admin/CompanyAds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyAdId,AdTitle,AdSubTitle,AdDescribe,CompanyId")] CompanyAd companyAd)
        {
            if (id != companyAd.CompanyAdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyAd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyAdExists(companyAd.CompanyAdId))
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
            return View(companyAd);
        }

        // GET: Admin/CompanyAds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyAd = await _context.CompanyAds
                .FirstOrDefaultAsync(m => m.CompanyAdId == id);
            if (companyAd == null)
            {
                return NotFound();
            }

            return View(companyAd);
        }

        // POST: Admin/CompanyAds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyAd = await _context.CompanyAds.FindAsync(id);
            _context.CompanyAds.Remove(companyAd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyAdExists(int id)
        {
            return _context.CompanyAds.Any(e => e.CompanyAdId == id);
        }
    }
}
