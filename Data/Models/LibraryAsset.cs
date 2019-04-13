using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class LibraryAsset {
        public int Id { get; set; }
        public virtual LibraryBranch Location { get; set; }
        public virtual Status Status { get; set; }
        public Asset AssetDetail { get; set; }
    }
}