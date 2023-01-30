using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;

namespace RoyalCars.Controllers
{
    public class CarsController : Controller
    {
        private readonly RoyalDbContext _context;
        private readonly IWebHostEnvironment _enviroment;

        public CarsController(RoyalDbContext context, IWebHostEnvironment enviroment)
        {
            _context = context;
            _enviroment = enviroment ;

        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var royalDbContext = _context.Cars.Include(c => c.Company);
            return View(await royalDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        public IActionResult CarCompany(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car =_context.Cars.Where(c=>c.CompanyId==id);
               
             
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
               string Imgname = UploodedFile(car);
                Car cr = new Car
                {
                    Img = Imgname,
                    CarDescribe = car.CarDescribe,
                    CarDistance = car.CarDistance,
                    CarModel = car.CarModel,
                    CarName = car.CarName,
                    CarTyp= car.CarTyp,
                    CompanyId= car.CompanyId,
                    ReserveCost= car.ReserveCost,
                    OtherPerties= car.OtherPerties,
                    CreationDate = DateTime.Now

                };
                _context.Cars.Add(cr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", car.CompanyId);
            ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryName", car.FactoryId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", car.CompanyId);
            //ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryName", car.FactoryId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyName", car.CompanyId);
            //ViewData["FactoryId"] = new SelectList(_context.Factories, "FactoryId", "FactoryName", car.FactoryId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Company)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
        private string UploodedFile(CarViewModel carImg)
        {
            string wwwPath = this._enviroment.WebRootPath;
            string contentPathPath = this._enviroment.ContentRootPath;
            string path = Path.Combine(this._enviroment.WebRootPath, "Uploads");

            if (!Directory.Exists(path))

            {
                Directory.CreateDirectory(path);

            }


            string fileName= Path.GetFileNameWithoutExtension(carImg.Img.FileName); 

              string newName = fileName + Guid.NewGuid().ToString() + Path.GetExtension(carImg.Img.FileName);

            using (FileStream stream = new FileStream(Path.Combine(path, newName), FileMode.Create))

            {
                carImg.Img.CopyTo(stream);
            }
            return "\\Uploads\\" + newName;
        }
    }
}
