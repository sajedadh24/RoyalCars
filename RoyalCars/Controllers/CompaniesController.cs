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
    public class CompaniesController : Controller
    {
        private readonly RoyalDbContext _context;
        private readonly IWebHostEnvironment _enviroment ;


        public CompaniesController(RoyalDbContext context, IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                string Imgname = UploodedFile(company);
                Company co = new Company
                {
                    CompanyName = company.CompanyName,
                    mobileNumber1 = company.mobileNumber1,
                    FacebookURL = company.FacebookURL,
                    TwitterURL= company.TwitterURL,
                    InstagramURL=company.InstagramURL,
                    Img= Imgname,
                    MembershipFee=company.MembershipFee,
                    CompanyLocation=company.CompanyLocation,
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.Now
                };
                _context.Companies.Add(co);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,CompanyName,mobileNumber1,FacebookURL,TwitterURL,InstagramURL,Img,CompanyLocation,MembershipFee,CreationDate,IsActive,IsDeleted")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
        private string UploodedFile(CompanyViewModel carImg)
        {
            string wwwPath = this._enviroment.WebRootPath;
            string contentPathPath = this._enviroment.ContentRootPath;
            string path = Path.Combine(this._enviroment.WebRootPath, "Uploads");

            if (!Directory.Exists(path))

            {
                Directory.CreateDirectory(path);

            }


            string fileName = Path.GetFileNameWithoutExtension(carImg.Img.FileName);

            string newName = fileName + Guid.NewGuid().ToString() + Path.GetExtension(carImg.Img.FileName);

            using (FileStream stream = new FileStream(Path.Combine(path, newName), FileMode.Create))

            {
                carImg.Img.CopyTo(stream);
            }
            return "../Uploads/" + newName;
        }
    }


    }


    

