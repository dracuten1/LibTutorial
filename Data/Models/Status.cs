using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class Status {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AssetInLibrary> LibraryAssets { get; set; }
    }
}