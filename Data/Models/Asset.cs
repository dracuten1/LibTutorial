using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models {
    public class Asset {
        public int Id { get; set; }
        public string Title { get; set; }   
        public int Year { get; set; }    
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual ICollection<LibraryAsset> LibraryAssets { get; set; }
    }
}
