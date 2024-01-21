
using FinalExamApp.DAL;
using FinalExamApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalExamApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM()
            {
                doctors = _context.doctors.ToList()
            };
            return View(homevm);
        }

    }
}