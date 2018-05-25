using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetFinder.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult Search(string searchType)
        {
            if (searchType == "Find")
            {
                ViewBag.HeaderText1 = "FIND";
                ViewBag.HeaderText2 = "FIND2";
            }
            else if (searchType == "Found")
            {
                ViewBag.HeaderText1 = "FOUND";
                ViewBag.HeaderText2 = "FOUND2";
            }
            
            return View();
        }

        public IActionResult Find()
        {
            ViewBag.HeaderText1 = "Test1";
            ViewBag.HeaderText2 = "Test2";
            return View();
        }

        public IActionResult Found() => View();

        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}