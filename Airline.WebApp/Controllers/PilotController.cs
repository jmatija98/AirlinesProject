using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Data.UnitOfWork;
using Airline.Domain;
using Airline.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airline.WebApp.Controllers
{
    public class PilotController : Controller
    {
        private readonly IUnitOfWork uof;
        public PilotController(IUnitOfWork uof)
        {
            this.uof = uof;
        }
        public ActionResult Index()
        {
            List<Airlines> airlineList = uof.Airline.GetAll();
            List<Pilot> pilotsList = uof.Pilot.GetAll();

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
            return View();
        }

        // POST: PilotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
