using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetFinder.Models;

namespace PetFinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Find() => View();

        public IActionResult Found() => View();

        public IActionResult About()
        {
            ViewData["Message"] = "Connecting lost pets and owners.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Don't call us, we'll call you.";
            return View();
        }

        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}
