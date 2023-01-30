using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class Car : SharedProp
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CarModel { get; set; }
        public string CarTyp { get; set; }
        [Display(Name = "ReserveCost/Day")]
        public string ReserveCost { get; set; }
        public string CarDistance { get; set; }
        //gps..
        public string OtherPerties{ get; set; }
        public string Img { get; set; }
        [Display(Name = "Distance/Km")]
        public string CarDescribe{ get; set; }
        public DataType StaData { get; set; }
        public DataType EndData { get; set; }
       
        public string UserId { get; set; }
        //public int FactoryId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
       
    }
}
