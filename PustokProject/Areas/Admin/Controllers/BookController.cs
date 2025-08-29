using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokProject.appDbContext;
using PustokProject.Models;

namespace PustokProject.Areas.Admin.Controllers
{

    [Area("Admin")]  
    public class BookController : Controller
    {
        private readonly PustokDbContext _pustokDbContext;
        public BookController(PustokDbContext pustokDbContext)
        {
            _pustokDbContext = pustokDbContext;

        }
        public IActionResult Index()
        {
            List<Book> books = _pustokDbContext.Books
                .Include(x => x.Author)
                .Include(x => x.Genre)
                .ToList();


            return View(books);
        }
        public IActionResult Create()
        {
            ViewBag.Tags = _pustokDbContext.Tags.ToList();
            ViewBag.Genres = _pustokDbContext.Genres.ToList();
            ViewBag.Authors = _pustokDbContext.Authors.ToList();
            return View();
        }

    }
}
