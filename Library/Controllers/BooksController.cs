using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(UserManager<ApplicationUser> userManager, LibraryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Book> model = _db.Books.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "AuthorName");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Book book, int AuthorId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            book.User = currentUser;
            _db.Books.Add(book);
            if (AuthorId != 0)
            {
                _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisBook = _db.Books
                .Include(book => book.Authors)
                .ThenInclude(join => join.Author)
                .Include(book => book.User)
                .FirstOrDefault(book => book.BookId == id);
            return View(thisBook);
        }

        public ActionResult Edit(int id)
        {
            var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
            if (thisBook == null)
            {
                return RedirectToAction("Details", new {id = id});
            }
            ViewBag.AuthorId = new SelectList(_db.Authors, "AuthorId", "Name");
            //ViewBag.PatronId = new SelectList(_db.Patrons, "PatronId", "Name");
            return View(thisBook);
        }

        [HttpPost]
        public ActionResult Edit(Book book, int AuthorId, int PatronId)
        {
            if (AuthorId !=0)
            {
                _db.AuthorBook.Add(new AuthorBook() { AuthorId = AuthorId, BookId = book.BookId });
            }
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisBook = _db.Books
                .Include(book => book.Authors)
                .ThenInclude(join => join.Author)
                .FirstOrDefault(book => book.BookId == id);
            if (thisBook == null)
            {
                return RedirectToAction("Details", new {id = id});
            }
            return View(thisBook);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id, int joinId)
        {
            if (joinId != 0)
            {
                var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
                _db.AuthorBook.Remove(joinEntry);
                var thisBook = _db.Books
                    .Include(book => book.Authors)
                    .ThenInclude(join => join.Author)
                    .FirstOrDefault(book => book.BookId == id);
                _db.Books.Remove(thisBook);
                _db.SaveChanges();
            }
            else
            {
                var thisBook = _db.Books
                    .Include(book => book.Authors)
                    .ThenInclude(join => join.Author)
                    .FirstOrDefault(book => book.BookId == id);
                _db.Books.Remove(thisBook);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAuthor(int joinId)
        {
            var joinEntry = _db.AuthorBook.FirstOrDefault(entry => entry.AuthorBookId == joinId);
            _db.AuthorBook.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}