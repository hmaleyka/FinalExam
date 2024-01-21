
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExamApp.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

    }
}