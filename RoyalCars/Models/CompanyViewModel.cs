using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class CompanyViewModel
    {

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string mobileNumber1 { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public IFormFile Img { get; set; }
        public string CompanyLocation { get; set; }
        public decimal MembershipFee { get; set; }
    }
}
