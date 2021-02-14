using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.WebApp.Models
{
    public class EditAirlinesViewModel
    {
        public string Name { get; set; }
        public int YearFounded { set; get; }
        public int NumberOfPlanes { set; get; }
        public int CountryID { set; get; }
        public List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Countries { set; get; }
    }
}
