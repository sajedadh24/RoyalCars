using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class CompanyAd 
    {
        public int CompanyAdId { get; set; }
        public string AdTitle{ get; set; }
        public string AdSubTitle{ get; set; }
        public string AdDescribe { get; set; }
        public int CompanyId { get; set; }

    }
}
