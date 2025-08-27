using Microsoft.AspNetCore.Mvc;

namespace PustokProject.Areas.Admin.Controllers
{

    [Area("Admin")]  
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
