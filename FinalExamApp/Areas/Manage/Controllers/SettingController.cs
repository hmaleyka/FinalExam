﻿

namespace FinalExamApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    [AutoValidateAntiforgeryToken]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Setting> settings= _context.setting.ToList();
            return View(settings);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            Setting setting = _context.setting.FirstOrDefault(setting => setting.Id == id);
            UpdateSettingVM vm = new UpdateSettingVM()
            {
                Key = setting.Key,
                Value = setting.Value,
            };
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSettingVM  settingvm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Setting setting = await  _context.setting.FirstOrDefaultAsync(setting => setting.Id == settingvm.Id);
            setting.Key = settingvm.Key;
            setting.Value = settingvm.Value;
            await  _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));         
        }

        public IActionResult Delete(int Id)
        {
            var setting = _context.setting.FirstOrDefault(setting => setting.Id == Id);
            if (setting == null)
            {
                return View();
            }
            _context.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
