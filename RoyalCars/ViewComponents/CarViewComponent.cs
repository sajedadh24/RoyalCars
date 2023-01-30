using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly RoyalDbContext _db;

        public CarViewComponent(RoyalDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var data = _db.Cars.OrderByDescending(x => x.CreationDate).Take(20);
            return View(data);
        }
    }
}
