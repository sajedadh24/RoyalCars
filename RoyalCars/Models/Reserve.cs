using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class Reserve
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
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

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


    }
}
