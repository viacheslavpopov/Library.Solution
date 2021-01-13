using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorsController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Author> model = _db.Authors.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisAuthor = _db.Authors
                .Include(author => author.Books)
                .ThenInclude(join => join.Book)
                .FirstOrDefault(author => author.AuthorId == id);
            return View(thisAuthor);
        }

        public ActionResult Edit(int id)
        {
            var thisAuthor = _db.Authors.FirstOrDefault(author => author.AuthorId == id);
            ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
            return View(thisAuthor);
        }

        [HttpPost]
        public ActionResult Edit(Author author, int BookId)
        {
            if (BookId !=0)
            {
                _db.AuthorBook.Add(new AuthorBook() { BookId = BookId, AuthorId = author.AuthorId });
            }
            _db.Entry(author).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisAuthor = _db.Authors
                .Include(author => author.Books)
                .ThenInclude(join => join.Book)
                .FirstOrDefault(author => author.AuthorId == id);
            if (thisAuthor == null)
            {
                return RedirectToAction("Details", new { id= id});
            }
            return View(thisAuthor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int joinId)
        {
            if (joinId != 0)
            {
                var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
                _db.AuthorBook.Remove(joinEntry);
                var thisAuthor = _db.Authors
                    .Include(author => author.Books)
                    .ThenInclude(join => join.Book)
                    .FirstOrDefault(author => author.AuthorId == id);
                _db.Authors.Remove(thisAuthor);
                _db.SaveChanges();
            }
            else
            {
                var thisAuthor = _db.Authors
                    .Include(author => author.Books)
                    .ThenInclude(join => join.Book)
                    .FirstOrDefault(author => author.AuthorId == id);
                _db.Authors.Remove(thisAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteBook(int joinId)
        {
            var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
            _db.AuthorBook.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}