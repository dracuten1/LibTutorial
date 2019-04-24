using System.ComponentModel.DataAnnotations;

namespace Domain.Models {
    public class AssetInLibrary {
        public int Id { get; set; }
        public virtual LibraryBranch Location { get; set; }
        public virtual Status Status { get; set; }
        public Product Product { get; set; }
    }
}