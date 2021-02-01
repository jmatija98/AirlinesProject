using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class AddPilotViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Miles { get; set; }
        public int AirlinesID { get; set; }
        public List<SelectListItem> Airlines { set; get; }
    }
}
