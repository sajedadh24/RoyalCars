using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.Models.ViewData
{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
