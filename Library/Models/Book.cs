using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public Book()
        {
            this.Patrons = new HashSet<BookPatron>();
        }
        public int BookId { get; set; }
        public string Title { get; set; }
        public bool CheckedOut { get; set; } = false;
        // Stretch:
        // [Display(Name="Date")]
        // [DataType(DataType.Date)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd")]
        // public DateTime CheckOutDate { get; set; } = DateTime.Now;
        [Display(Name="Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14); // View: @hidden
        public bool Overdue { get; set; } = false;
        public virtual ApplicationUser User { get; set; }
        public int CopyId { get; set; }
        public virtual Copy Copy { get; set; }
        public virtual ICollection<BookPatron> Patrons { get; }
    }
}