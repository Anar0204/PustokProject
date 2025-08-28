using Microsoft.AspNetCore.Mvc;
using PustokProject.appDbContext;
using PustokProject.Models;

namespace PustokProject.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AuthorController : Controller
    {

        private readonly PustokDbContext _context;

        public AuthorController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
                return View();
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.SingleOrDefault(x => x.Id == id);
            if (author == null) return View("Error");
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
                return View();
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.SingleOrDefault(x => x.Id == id);
            if (author == null) return View("Error");
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
