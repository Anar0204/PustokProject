using Microsoft.AspNetCore.Mvc;
using PustokProject.appDbContext;
using PustokProject.helpers;
using PustokProject.Models;

namespace PustokProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;
        public SliderController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _pustokDbContext.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            slider.BackgrounImageName = FileHelper.SaveFile(slider.ImageFile, "slider");

            _pustokDbContext.Sliders.Add(slider);
            _pustokDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _pustokDbContext.Sliders.SingleOrDefault(x => x.Id == id);
            if (slider == null) return View("Error");
            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            if(slider.ImageFile != null)
            {
                FileHelper.DeleteFile(slider.BackgrounImageName, "slider");
                slider.BackgrounImageName = FileHelper.SaveFile(slider.ImageFile, "slider");
            }
            _pustokDbContext.Sliders.Update(slider);
            _pustokDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Slider slider = _pustokDbContext.Sliders.SingleOrDefault(x => x.Id == id);
            if (slider == null) return View("Error");

            FileHelper.DeleteFile(slider.BackgrounImageName, "slider");
            _pustokDbContext.Sliders.Remove(slider);
            _pustokDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            Slider slider = _pustokDbContext.Sliders.SingleOrDefault(x => x.Id == id);
            if (slider == null) return View("Error");
            return View(slider);
        }
    }
}
