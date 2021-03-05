
using Airline.Data.UnitOfWork;
using Airline.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Airline.WebApp.Filters;

namespace Airline.WebApp.Controllers
{
    [AdminLoggedIn]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CountryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            List<Country> allCountries = unitOfWork.Country.GetAll();
            return View("Index", allCountries);
        }

        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = true;
            return View();
            
        }


        [HttpPost]
        public ActionResult Create([FromForm]Country c)
        {
            ViewBag.IsLoggedIn = true;
            bool exists = false;
            List<Country> countriesAll = unitOfWork.Country.GetAll();
            if (countriesAll.Any(item => item.Name == c.Name))
            {
                exists = true;
            }
            if (exists == true)
            {
                ModelState.AddModelError(string.Empty, "Country already exists");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.Country.Add(c);
                unitOfWork.Commit();
                return Index();
            }
            else return Create();
        }

        public ActionResult Edit([FromRoute(Name = "id")] int idCountry)
        {
            ViewBag.IsLoggedIn = true;

            Country country = unitOfWork.Country.FindById(idCountry);
            return View(country);
        }
        [HttpPost]
        public ActionResult Edit([FromForm(Name = "name")] String name, [FromRoute(Name = "id")]  int id)
        {
            ViewBag.IsLoggedIn = true;
            Country c = new Country
            {
                CountryID = id,
                Name = name
            };
            unitOfWork.Country.change(c);
            unitOfWork.Commit();
            return Index();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.IsLoggedIn = true;

            unitOfWork.Country.Delete(id);
            unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
