using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models.ViewData
{
    public class AdvertisementViewModel
    {
        public int AdvertisementId { get; set; }
        public string AdvertisementTitle { get; set; }
        public string AdDescribe { get; set; }
        public IFormFile Img { get; set; }
    }
}
