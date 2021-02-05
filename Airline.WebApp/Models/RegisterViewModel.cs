using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class RegisterViewModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string passwordRepeat { get; set; }
    }
}
