using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models {
    public class Genre {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GenreBook> GenreBook { get; set; }
    }
}
