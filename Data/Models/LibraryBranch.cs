using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models {
    public class LibraryBranch {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<AssetInLibrary> LibraryAssets { get; set; }

        public string ImageUrl { get; set; }
    }
}