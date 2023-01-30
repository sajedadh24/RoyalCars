using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class Company : SharedProp
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string mobileNumber1 { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string VideURL { get; set; }
        public string InstagramURL { get; set; }
        public string Img {get; set;}
        public string CompanyLocation { get; set;}
        public string UserId { get; set;}
        public decimal MembershipFee {get; set; }

    }
}
