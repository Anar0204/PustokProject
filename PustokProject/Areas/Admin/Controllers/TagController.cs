using Microsoft.AspNetCore.Mvc;

namespace PustokProject.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
