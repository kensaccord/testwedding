using System.Linq;
using kkwedding.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

namespace kkwedding.Controllers
{
    public class GuestsController : Controller
    {
        private ApplicationDbContext _context;

        public GuestsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Guests
        public IActionResult Index()
        {
            return View(_context.Guest.ToList());
        }

        // GET: Guests/Details/5
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

        // GET: Guests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
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

        // GET: Guests/Edit/5
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

        // POST: Guests/Edit/5
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

        // GET: Guests/Delete/5
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

        // POST: Guests/Delete/5
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
