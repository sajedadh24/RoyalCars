using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models.ViewData
{
    public class RoyalViewModel
    {
        public IList<Company> Companies { get; set; }
        public IList<Factory> Factories { get; set; }
        public IList<Car> Cars { get; set; }
        public IList<About> Abouts { get; set; }
        public IList<Advertisement> Advertisements { get; set; }
        public IList<CompanyAd> CompanyAds { get; set; }
        public IList<Service> Services { get; set; }
        public IList<Slider> Sliders { get; set; }
        
        public Car MyCar { get; set; }
        public Reserve Reserve { get; set; }

    }
}
