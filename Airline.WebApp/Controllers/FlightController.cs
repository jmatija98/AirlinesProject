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
            List<Airlines> airlinesAll = uow.Airlines.GetAll();
            FlightsWithAirlineWithPilot model = new FlightsWithAirlineWithPilot
            {
                Flights = flightsAll,
                Pilots = pilotsAll,
                Airlines = airlinesAll

            };
            return View(model);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.IsLoggedIn = true;

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
            ViewBag.IsLoggedIn = true;

            if(ModelState.IsValid)
            {
                Flight f = new Flight
                {
                    Date = model.Date,
                    DurationInMinutes = model.DurationInMinutes,
                    StartDestination = model.StartDestination,
                    EndDestination = model.EndDestination,
                    Price=model.Price,
                    PilotID = model.PilotID
                };
                uow.Flight.Add(f);
                uow.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Create();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            ViewBag.IsLoggedIn = true;

            List<Pilot> pilotsAll = uow.Pilot.GetAll();
            List<SelectListItem> pilots = new List<SelectListItem>();
            foreach (Pilot pilot in pilotsAll)
            {
                pilots.Add(new SelectListItem {
                    Text = pilot.FirstName + " " + pilot.LastName,
                    Value = pilot.PilotID.ToString() });
            }
            Flight flight = uow.Flight.FindById(id);
            AddFlightViewModel model = new AddFlightViewModel
            {
                Date = flight.Date,
                DurationInMinutes = flight.DurationInMinutes,
                StartDestination = flight.StartDestination,
                EndDestination = flight.EndDestination,
                Price=flight.Price,
                Pilots = pilots

            };

            return View(model);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] AddFlightViewModel model, [FromRoute(Name = "id")] int id)
        {
            ViewBag.IsLoggedIn = true;

            if(ModelState.IsValid)
            {
                    Flight f = new Flight
                    {
                        FlightID = id,
                        Date = model.Date,
                        DurationInMinutes = model.DurationInMinutes,
                        StartDestination = model.StartDestination,
                        EndDestination = model.EndDestination,
                        Price = model.Price,
                        PilotID = model.PilotID
                    };
                    uow.Flight.Change(f);
                    uow.Commit();
                    return RedirectToAction(nameof(Index));
                }
            else
            {
                return Edit(id);
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.IsLoggedIn = true;

            uow.Flight.Delete(id);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        [NotLoggedIn]
        public ActionResult Search([FromForm] SearchFlightsViewModel m)
        {
            List<Airlines> airlinesAll = uow.Airlines.GetAll();
            List<Pilot> pilotsAll = uow.Pilot.GetAll();
            List<Flight> flightsAll = uow.Flight.GetAll();
            Flight f1 = uow.Flight.FindById(m.startID);
            String start = f1.StartDestination;
            Flight f2 = uow.Flight.FindById(m.endID);
            String end = f2.EndDestination;
            DateTime onlyDate = m.Date.Date;

            List<Flight> flightsSearched = new List<Flight>();
            foreach(Flight flight in flightsAll)
            {
                if(flight.Date.Date==onlyDate && flight.StartDestination==start && flight.EndDestination == end)
                {
                    flightsSearched.Add(new Flight
                    {
                        StartDestination = flight.StartDestination,
                        EndDestination = flight.EndDestination,
                        Date = flight.Date,
                        DurationInMinutes = flight.DurationInMinutes,
                        PilotID = flight.PilotID,
                        Price = flight.Price
                    }
                    );
                }
            }
            if (flightsSearched.Count == 0)
            {
                
            }
            FlightsWithAirlineWithPilot model = new FlightsWithAirlineWithPilot
            {
                Flights = flightsSearched,
                Airlines=airlinesAll,
                Pilots=pilotsAll
            };
            return View("SearchFlights",model);
        }

        [NotLoggedIn]
        public ActionResult Search()
        {
            List<Flight> flightsAll = uow.Flight.GetAll();
            List<SelectListItem> startDestinations = new List<SelectListItem>();
            List<SelectListItem> endDestinations = new List<SelectListItem>();
            foreach (Flight flight in flightsAll)
            {
                if(!startDestinations.Any(item=>item.Text==flight.StartDestination))
                    startDestinations.Add(new SelectListItem
                    {
                        Text = flight.StartDestination,
                        Value = flight.FlightID.ToString()
                    }
                );
            }

            foreach (Flight flight in flightsAll)
            {
                if (!endDestinations.Any(item => item.Text == flight.EndDestination))
                    endDestinations.Add(new SelectListItem
                    {
                        Text = flight.EndDestination,
                        Value = flight.FlightID.ToString()
                    }
                );
            }

            SearchFlightsViewModel model = new SearchFlightsViewModel
            {
                startDestinations = startDestinations,
                endDestinations = endDestinations
            };
            return View("Search",model);
           
        }
    }
}
