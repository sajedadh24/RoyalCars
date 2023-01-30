using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Controllers
{
    public class ReserveController : Controller
    {
        private readonly RoyalDbContext db;
        public ReserveController(RoyalDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            
            return View(db.Reserves.ToList());
        }
        public IActionResult Create()
        {
           
            ViewBag.Pic  = new SelectList(db.Reserves, "ReserveId", "Pickuplocation");
            ViewBag.Drop = new SelectList(db.Reserves, "ReserveId", "Droplocation");
            ViewBag.Drop = new SelectList(db.Reserves, "ReserveId", "Droplocation");
            ViewBag.car  = new SelectList(db.Reserves, "CarId", "CarName");
            ViewBag.comp = new SelectList(db.Reserves, "CompanyId", "Droplocation");
            return View(new ReserveViewModel());
        }
        [HttpPost]
        public async Task< IActionResult> Create(ReserveViewModel reserve)
        {
            if( ModelState.IsValid )
            {
                Reserve opj = new Reserve()
                {
                    CarId = reserve.CarId,
                    CompanyId = reserve.CompanyId,
                    Droplocation = reserve.Droplocation,
                    Email = reserve.Email,
                    Pickuplocation = reserve.Pickuplocation,
                    EndtDate = reserve.EndtDate,
                    StartTime = reserve.StartTime,
                    EndTime=reserve.EndTime,
                    StartDate=reserve.StartTime,
                    MobileNumber = reserve.MobileNumber
                };
                db.Reserves.Add(opj);
                await db.SaveChangesAsync();
            };
            return View(reserve);

        }
    }
}
