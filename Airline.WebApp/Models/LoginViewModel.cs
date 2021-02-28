using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password!")]
        public string password { get; set; }
    }
}
