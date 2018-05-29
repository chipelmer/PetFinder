using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Models;

namespace PetFinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        //public IActionResult Find() => View();

        //public IActionResult Found() => View();

        public IActionResult NewPet() => View();

        public IActionResult About()
        {
            //ViewBag.Message = "Don't just put up flyers.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Don't call us, we'll call you.";
            return View();
        }

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}
