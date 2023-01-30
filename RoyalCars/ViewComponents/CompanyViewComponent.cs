using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.ViewComponents
{
    public class CompanyViewComponent : ViewComponent
     {
        private readonly RoyalDbContext _db;

        public CompanyViewComponent(RoyalDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var data = _db.Companies;
            return View (data);
        }
    }
}
