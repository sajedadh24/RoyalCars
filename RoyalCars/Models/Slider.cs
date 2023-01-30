using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        [Required(ErrorMessage = "Enter Slider Title")]
        [Display(Name = "Menu Slider Title")]
        public string SliderTitle { get; set; }
        [Required(ErrorMessage = "Enter Sub Title")]
        [Display(Name = "Menu Sub  Title")]
        public string SubTitle { get; set; }
        public string Img { get; set; }

    }
}
