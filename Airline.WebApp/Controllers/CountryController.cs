
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

        public ActionResult Details([FromRoute(Name = "id")]int idCountry)
        {
            Country country = unitOfWork.Country.FindById(idCountry);
            return View(country);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add([FromForm]Country c)
        {
            unitOfWork.Country.Add(c);
            unitOfWork.Commit();
            return Index();
        }

        public ActionResult Edit([FromRoute(Name = "id")] int idCountry)
        {
            Country country = unitOfWork.Country.FindById(idCountry);
            return View(country);
        }
        
        public ActionResult Change([FromForm(Name = "name")] String name, [FromForm(Name = "idx")] int id)
        { 
            unitOfWork.Country.changeName(id,name);
            unitOfWork.Commit();
            return Index();
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Country.Delete(id);
            unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
