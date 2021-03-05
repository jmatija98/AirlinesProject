using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airline.Data.AdminUnitOfWork;
using Airline.Domain;
using Airline.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airline.WebApp.Controllers
{
    public class AdminController : Controller
    {

        private readonly IAdminUnitOfWork uow;

        public AdminController(IAdminUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login([FromForm] LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Admin a = uow.Admins.getByUsernamePassword(model.Username, model.password);
                    HttpContext.Session.SetInt32("id", a.AdminId);

                    return RedirectToAction("Index", "Flight");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Wrong credentials! Try again");
                    return View();
                }
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View("Register");
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] RegisterViewModel model)
        {
            if (model.password == model.passwordRepeat)
            {
                Admin a = new Admin { Username = model.username, Password = model.password };
                uow.Admins.Add(a);
                uow.Commit();
                return View("Login");
            }
            else
            {
                return View("Register");
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
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

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
