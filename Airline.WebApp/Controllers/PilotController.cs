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
    public class PilotController : Controller
    {
        private readonly IUnitOfWork uow;
        public PilotController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
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
            ViewBag.IsLoggedIn = true;

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
            ViewBag.IsLoggedIn = true;

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
        public ActionResult Edit([FromRoute(Name = "id")] int pilotID)
        {
            ViewBag.IsLoggedIn = true;

            List<Airlines> airlinesAll = uow.Airline.GetAll();
            List<SelectListItem> airlines = new List<SelectListItem>();
            foreach (Airlines airline in airlinesAll)
            {
                airlines.Add(new SelectListItem { Text = airline.Name, Value = airline.AirlinesID.ToString() });
            }
            Pilot pilot = uow.Pilot.FindById(pilotID);
            AddPilotViewModel model = new AddPilotViewModel
            {
                FirstName = pilot.FirstName,
                LastName = pilot.LastName,
                Miles = pilot.Miles,
                Airlines = airlines

            };

            return View(model);
        }

        // POST: PilotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] AddPilotViewModel model, [FromRoute(Name = "id")] int id)
        {
            ViewBag.IsLoggedIn = true;

            try
            {
                Pilot p = new Pilot
                {
                    PilotID = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Miles=model.Miles,
                    AirlinesId=model.AirlinesID

                };
                uow.Pilot.Change(p);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));

            }
        }

        // GET: PilotController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.IsLoggedIn = true;

            uow.Pilot.Delete(id);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
