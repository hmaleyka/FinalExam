using Microsoft.AspNetCore.Mvc;

namespace FinalExamApp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Setting> settings= _context.setting.ToList();
            return View(settings);
        }

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
            _context.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
