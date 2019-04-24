using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models {
    public class GenreBook {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
