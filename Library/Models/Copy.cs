// using System.Collections.Generic;

// namespace Library.Models
// {
//     public class Copy // one-to-many w/ books
//     {
//         public Copy()
//         {
//             this.Books = new HashSet<Book>();
//         }

//         public int CopyId { get; set; }
//         //public int NumOfBooks { get; set; } --> can get from List.TakeWhile or Where(param).Count(); // // = ViewBag.CopyId.Count;
//         //Available books: NumOfBooks - CheckedOut#
//         // make sure primary keys reset to ordered list if deletions

//         //Stretch:
//         // public int NumOfEBooks { get; set; }
//         // public int NumOfAudiobooks { get; set; }
//         // public int NumOfPhysical { get; set; }
//         public virtual ICollection<Book> Books { get; set; }
//     }
// }