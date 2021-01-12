using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Author> Authors { get; set; }
        // public DbSet<Copy> Copies { get; set; }
        public DbSet<BookPatron> BookPatron { get; set; }
        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Checkout> Checkout { get; set; }

        public LibraryContext(DbContextOptions options) : base(options) { }
    }
}