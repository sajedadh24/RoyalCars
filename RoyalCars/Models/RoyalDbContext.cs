using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class RoyalDbContext : IdentityDbContext
    {        public RoyalDbContext(DbContextOptions<RoyalDbContext> options): base(options)
        {

        }

        public DbSet<Advertisement>Advertisements  { get; set; }
        
        public DbSet<Car> Cars  { get; set; }
        public DbSet<Company>Companies  { get; set; }
        public DbSet<CompanyAd> CompanyAds  { get; set; }
        public DbSet<Service> Services  { get; set; }
        public DbSet<Slider> Sliders  { get; set; }
        public DbSet<Factory> Factories  { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }


    }
}
