using System.Linq;
using kkwedding.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

namespace kkwedding.Controllers
{
    [Authorize]
    public class GuestController : Controller
    {
        private ApplicationDbContext _context;

        public GuestController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Guest
        public IActionResult Index()
        {
            return View(_context.Guest.ToList());
        }

        // GET: Guest/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Guest guest = _context.Guest.Single(m => m.Id == id);
            if (guest == null)
            {
                return HttpNotFound();
            }

            return View(guest);
        }

        // GET: Guest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Guest.Add(guest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: Guest/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Guest guest = _context.Guest.Single(m => m.Id == id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: Guest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _context.Update(guest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: Guest/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Guest guest = _context.Guest.Single(m => m.Id == id);
            if (guest == null)
            {
                return HttpNotFound();
            }

            return View(guest);
        }

        // POST: Guest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Guest guest = _context.Guest.Single(m => m.Id == id);
            _context.Guest.Remove(guest);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
