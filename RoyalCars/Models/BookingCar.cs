using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class BookingCar
    {
        public Car Car { get; set; }
        public Reserve Reserve { get; set; }
    }
}
