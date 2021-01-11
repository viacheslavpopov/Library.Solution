using System.Collections.Generic;

namespace Library.Models
{
    public class Copy
    {
        public Copy()
        {
            this.Books = new HashSet<BookPatron>();
        }

        public int CopyId { get; set; }
        public int NumOfBooks { get; set; }
        //Stretch:
        // public int NumOfEBooks { get; set; }
        // public int NumOfAudiobooks { get; set; }
        // public int NumOfPhysical { get; set; }
    }
}
