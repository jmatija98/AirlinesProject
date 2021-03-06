﻿using System;
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
            
            List<Country> countriesAll = uow.Country.GetAll();
            List<Airlines> airlinesAll = uow.Airlines.GetAll();
            AirlinesWithCountries model = new AirlinesWithCountries
            {
                
                Airlines = airlinesAll,
                Countries=countriesAll

            };
            return View(model);
        }

        // GET: AirlinesController/Create
        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = true;

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
            ViewBag.IsLoggedIn = true;
            bool exists = false;
            List<Airlines> airlineAll = uow.Airlines.GetAll();
            if (airlineAll.Any(item => item.Name == m.Name))
            {
                exists = true;
            }
            if (exists == true)
            {
                ModelState.AddModelError(string.Empty, "Airline already exists");
            }
            if (ModelState.IsValid)
            {
                Airlines a = new Airlines
                {
                    Name=m.Name,
                    YearFounded=m.YearFounded,
                    NumberOfPlanes=m.NumberOfPlanes,
                    CountryId=m.CountryID
                };
                uow.Airlines.Add(a);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Create();
            }
        }

        // GET: AirlinesController/Edit/5
        public ActionResult Edit([FromRoute(Name = "id")] int AirlinesID)
        {
            ViewBag.IsLoggedIn = true;

            List<Country> countriesAll = uow.Country.GetAll();
            List<SelectListItem> countries = new List<SelectListItem>();
            foreach (Country country in countriesAll)
            {
                countries.Add(new SelectListItem { Text = country.Name, Value = country.CountryID.ToString() });
            }
            Airlines a = uow.Airlines.FindById(AirlinesID);
            AddAirlinesViewModel model = new AddAirlinesViewModel
            {
                Name = a.Name,
                YearFounded=a.YearFounded,
                NumberOfPlanes=a.NumberOfPlanes,
                Countries=countries
            };
            return View(model);
        }

        // POST: AirlinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] AddAirlinesViewModel model, [FromRoute(Name = "id")] int id)
        {
            ViewBag.IsLoggedIn = true;

            if(ModelState.IsValid)
            {
                Airlines a = new Airlines
                {
                    AirlinesID=id,
                    Name = model.Name,
                    YearFounded = model.YearFounded,
                    NumberOfPlanes = model.NumberOfPlanes,
                    CountryId = model.CountryID

                };
                uow.Airlines.Change(a);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Edit(id);
            }
        }

        // GET: AirlinesController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.IsLoggedIn = true;

            uow.Airlines.Delete(id);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
