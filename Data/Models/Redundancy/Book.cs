using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models {
    public class Book : Product {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string DeweyIndex { get; set; }
        public ICollection<GenreBook> GenreBook { get; set; }
    }
}
