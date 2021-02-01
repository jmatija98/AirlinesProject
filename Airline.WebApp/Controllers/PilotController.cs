using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Data.UnitOfWork;
using Airline.Domain;
using Airline.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Airline.WebApp.Controllers
{
    public class PilotController : Controller
    {
        private readonly IUnitOfWork uow;
        public PilotController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            List<Airlines> airlineList = uow.Airline.GetAll();
            List<Pilot> pilotsList = uow.Pilot.GetAll();

            PilotWithAirlineViewModel model = new PilotWithAirlineViewModel { Airlines = airlineList, Pilots = pilotsList };
            return View(model);
        }

        // GET: PilotController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PilotController/Create
        public ActionResult Create()
        {
            List<Airlines> airlineList = uow.Airline.GetAll();
            List<SelectListItem> airlineListItems = new List<SelectListItem>();
            foreach (Airlines a in airlineList)
            {
                airlineListItems.Add(new SelectListItem { Text = a.Name, Value = a.AirlinesID.ToString() });
            }
            AddPilotViewModel model = new AddPilotViewModel { Airlines = airlineListItems };
            return View(model);
        }

        // POST: PilotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AddPilotViewModel model)
        {
            try
            {
                Pilot p = new Pilot
                {
                    AirlinesId = model.AirlinesID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Miles = model.Miles
                };
                uow.Pilot.Add(p);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: PilotController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PilotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PilotController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PilotController/Delete/5
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
