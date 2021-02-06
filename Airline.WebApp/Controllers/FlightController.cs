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
    public class FlightController : Controller
    {

        private readonly IUnitOfWork uow;
        public FlightController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: FlightController
        public ActionResult Index()
        {
            ViewBag.IsLoggedIn = true;
            List<Flight> flightsAll = uow.Flight.GetAll();
            List<Pilot> pilotsAll = uow.Pilot.GetAll();
            List<Airlines> airlinesAll = uow.Airline.GetAll();
            FlightsWithAirlineWithPilot model = new FlightsWithAirlineWithPilot
            {
                Flights = flightsAll,
                Pilots = pilotsAll,
                Airlines = airlinesAll

            };
            return View(model);
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            List<Pilot> pilotsAll = uow.Pilot.GetAll();
            List<SelectListItem> p = new List<SelectListItem>();
            foreach (Pilot pilot in pilotsAll)
            {
                p.Add(new SelectListItem
                {
                    Text = pilot.FirstName+" "+pilot.LastName,
                    Value = pilot.PilotID.ToString()
                }
                    );
            }
            AddFlightViewModel model = new AddFlightViewModel
            {
                Pilots = p
            };
            return View(model);
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AddFlightViewModel model)
        {
            try
            {
                Flight f = new Flight
                {
                    Date = model.Date,
                    DurationInMinutes = model.DurationInMinutes,
                    StartDestination = model.StartDestination,
                    EndDestination = model.EndDestination,
                    PilotID = model.PilotID
                };
                uow.Flight.Add(f);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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
