using Microsoft.AspNetCore.Mvc;
using PustokProject.appDbContext;
using PustokProject.Models;

namespace PustokProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly PustokDbContext _context;

        public TagController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tags = _context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            if (!ModelState.IsValid) return View(tag);
            _context.Tags.Update(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null) return NotFound();
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
