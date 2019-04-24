using System;

namespace Domain.Models {
    public class Hold {
        public int Id { get; set; }
        public virtual AssetInLibrary LibraryAsset { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
