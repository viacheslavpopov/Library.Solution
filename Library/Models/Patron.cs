using System.Collections.Generic;

namespace Library.Models
{
    public class Patron
    {
        public Patron()
        {
            this.Books = new HashSet<BookPatron>();
        }

        public int PatronId { get; set; }
        public string PatronName { get; set;}
        public virtual ICollection<BookPatron> Books { get; set; }
    }
}