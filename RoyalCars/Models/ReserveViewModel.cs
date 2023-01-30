using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class ReserveViewModel
    {
        public int ReserveId { get; set; }
        public string FirstName { get; set; }
        public string Lastame { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Pickuplocation { get; set; }
        public string Droplocation { get; set; }
        public string Payment { get; set; }
        public string SpecialRequest { get; set; }
        public int CarId { get; set; }
        public int CompanyId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string EndtDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }
        public Car Car { get; set; }
        //public DateTime StartDateTime => DateTime.ParseExact($" {StartDate} {StartTime}", "mm/dd/yyyy , hh:mm tt", CultureInfo.GetCultureInfo("en-us"));
        //public DateTime EndDateTime => DateTime.ParseExact($" {EndtDate} {EndTime}", "mm/dd/yyyy , hh:mm tt", CultureInfo.GetCultureInfo("en-us"));
    }
}
