using Microsoft.AspNetCore.Mvc;

namespace PustokProject.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
