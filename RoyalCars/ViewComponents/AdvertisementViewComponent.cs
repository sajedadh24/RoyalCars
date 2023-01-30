using Microsoft.AspNetCore.Mvc;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.ViewComponents
{
    public class AdvertisementViewComponent : ViewComponent
    {
        private readonly RoyalDbContext _db;

        public AdvertisementViewComponent(RoyalDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var data = _db.Advertisements;
            return View(data);
        }
    }
}
