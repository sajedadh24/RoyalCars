using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;
using RoyalCars.Models.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Controllers
{
    public class HomeController : Controller
    {

        private readonly RoyalDbContext db;
        public HomeController(RoyalDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
           
            string Id= HttpContext.Session.GetString("userId");

            return View(db.Cars);

        }
        public IActionResult CarListing(int id)
        {
            RoyalViewModel model = new RoyalViewModel
            {
                Cars = db.Cars.Include(x=>x.Company).ToList(),
                MyCar = db.Cars.Find(id)

            };
            return View(model);
        }
        public IActionResult ViewMore()
        {
            return View();
        }
        public IActionResult CarBooking()
        {
            ViewData["CarId"] = new SelectList(db.Cars, "CarId", "CarName");
            ViewData["CompanyId"] = new SelectList(db.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: Admin/Reserves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CarBooking(Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                db.Add(reserve);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(db.Cars, "CarId", "CarName", reserve.CarId);
            ViewData["CompanyId"] = new SelectList(db.Companies, "CompanyId", "CompanyName", reserve.CompanyId);
            return View(reserve);
        }
      

        public IActionResult CarDetatl(int id)
        {
            RoyalViewModel model = new RoyalViewModel
            {
                Cars = db.Cars.Include(x=>x.Company).ToList(),
                Services = db.Services.ToList()
                ,MyCar=db.Cars.Find(id)

            };
            return View(model);
            //var data = db.Cars.Where(x => x.CarId == id).Include(c => c.Company);
            //return View(data);
        }

        public async Task<IActionResult> Rent()
        {
            return View(await db.Reserves.ToListAsync());
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Service()
        {
            RoyalViewModel model = new RoyalViewModel
            {
                Cars = db.Cars.ToList()
            };
            return View(model);
        }
        public IActionResult CompanyListing()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.UserId = HttpContext.Session.GetString("userId");
                db.Add(contactUs);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

    }
}
