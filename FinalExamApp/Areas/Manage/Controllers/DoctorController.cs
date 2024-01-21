using FinalExamApp.Areas.Manage.ViewModels;
using FinalExamApp.DAL;
using FinalExamApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace FinalExamApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DoctorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Doctor> doctors = _context.doctors.ToList();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorVM doctorvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Doctor doctor = new Doctor()
            {
                Name = doctorvm.Name,
                Position = doctorvm.Position,
                ImgUrl = doctorvm.Image.Upload(_env.WebRootPath, @"\Upload\Doctor\")
            };
            await _context.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update (int id)
        {
            Doctor doctor = await _context.doctors.Where(d => d.Id == id).FirstOrDefaultAsync();
            UpdateDoctorVM doctorvm = new UpdateDoctorVM()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Position = doctor.Position,
                ImgUrl = doctor.ImgUrl
            };
            return View(doctorvm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDoctorVM doctorvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Doctor doctor = await _context.doctors.FirstOrDefaultAsync(d => d.Id == doctorvm.Id);
            doctor.Name = doctorvm.Name;
            doctor.Position = doctorvm.Position;
            doctor.ImgUrl = doctorvm.Image.Upload(_env.WebRootPath, @"\Upload\Doctor\");
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int id)
        {
            Doctor doctor = _context.doctors.FirstOrDefault(d => d.Id == id);
            _context.Remove(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
