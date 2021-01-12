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
        public async Task <ActionResult> Create(Patron patron, int BookId)
        {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        patron.User = currentUser;
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
            .Include(patron => patron.User)
            .FirstOrDefault(patron => patron.PatronId == id);
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ViewBag.IsCurrentUser = userId != null ? userId == thisPatron.User.Id : false;
        return View(thisPatron);
        }
    }
}