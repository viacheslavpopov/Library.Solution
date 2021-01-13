using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Library.Models;
//new for authorizing
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class PatronsController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatronsController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
        List<Patron> model = _db.Patrons.ToList();
        return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Patron patron, int BookId)
        {
            _db.Patrons.Add(patron);
            if (BookId != 0)
            {
                _db.BookPatron.Add(new BookPatron() { BookId = BookId, PatronId = patron.PatronId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisPatron = _db.Patrons
                .Include(patron => patron.Books)
                .ThenInclude(join => join.Book)
                // .Include(patron => patron.Copies) // eh?
                // .ThenInclude(join => join.Copy)
                // OR ...
                // List<Copy> foundCopies = _db.Copies.Where(copy => copy.PatronId == id).ToList();
                //ViewBag.foundCopies = foundCopies;
                // .Include(patron => patron.User)
                .FirstOrDefault(patron => patron.PatronId == id);
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // ViewBag.IsCurrentUser = userId != null ? userId == thisPatron.User.Id : false;
            return View(thisPatron);
        }

        public ActionResult Edit(int id)
        {
            var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
            return View(thisPatron);
        }

        [HttpPost]
        public ActionResult Edit(Patron patron)
        {
            _db.Entry(patron).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
            return View(thisPatron);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisPatron = _db.Patrons.FirstOrDefault(patron => patron.PatronId == id);
            _db.Patrons.Remove(thisPatron);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddBook(int id)
        {
            var thisPatron = _db.Patrons.FirstOrDefault(patrons => patrons.PatronId == id);
            ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
            ViewBag.CheckedOut = new SelectList(_db.Books, "BookId", "CheckedOut");
            return View(thisPatron);
        }

        [HttpPost]
        public ActionResult AddBook(Patron patron, int BookId)
        {
            if (BookId != 0)
            {
                _db.BookPatron.Add(new BookPatron() { BookId = BookId, PatronId = patron.PatronId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int joinId)
        {
            var joinEntry = _db.BookPatron.FirstOrDefault(entry => entry.BookPatronId == joinId);
            _db.BookPatron.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}