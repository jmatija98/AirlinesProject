using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Data.UnitOfWork;
using Airline.Domain;
using Airline.WebApp.Filters;
using Airline.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.WebApp.Controllers
{
    [AdminLoggedIn]
    public class AirlinesController : Controller
    {
        private readonly IUnitOfWork uow;
        public AirlinesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: AirlinesController
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            List<Airlines> a = uow.Airline.GetAll();
            return View(a);
        }

        // GET: AirlinesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AirlinesController/Create
        public ActionResult Create()
        {
            List<Country> countryList = uow.Country.GetAll();
            List<SelectListItem> countries = new List<SelectListItem>();
            foreach(Country c in countryList)
            {
                countries.Add(new SelectListItem { Text = c.Name, Value=c.CountryID.ToString() }); 
            }
            AddAirlinesViewModel model = new AddAirlinesViewModel { Countries = countries };
            return View(model);
        }

        // POST: AirlinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AddAirlinesViewModel m)
        {
            try
            {
                Airlines a = new Airlines
                {
                    Name=m.Name,
                    YearFounded=m.YearFounded,
                    NumberOfPlanes=m.NumberOfPlanes,
                    CountryId=m.CountryID
                };
                uow.Airline.Add(a);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AirlinesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AirlinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddAirlinesViewModel model)
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirlinesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AirlinesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
