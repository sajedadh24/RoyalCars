using Microsoft.AspNetCore.Mvc;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.ViewComponents
{
    public class CompanyAdViewComponent : ViewComponent
    {
        private readonly RoyalDbContext _db;

        public CompanyAdViewComponent(RoyalDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var data = _db.CompanyAds;
            return View(data);
        }
    }
}
