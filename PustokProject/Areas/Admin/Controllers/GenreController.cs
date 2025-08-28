using Microsoft.AspNetCore.Mvc;
using PustokProject.appDbContext;
using PustokProject.Models;

namespace PustokProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
        private readonly PustokDbContext _context;

        public GenreController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            return View(genre);
        }

        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            if (!ModelState.IsValid) return View(genre);
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null) return NotFound();
            _context.Genres.Remove(genre);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
