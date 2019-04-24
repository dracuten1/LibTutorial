using System.Collections.Generic;
using System.Linq;

namespace Domain.Models {
    public class Product {
        public int Id { get; set; }
        public string Title { get; set; }   
        public int Year { get; set; }    
        public decimal Cost { get; set; }
        private List<string> _imageUrl { get; set; }
        public AssetCategory AssetCategory { get; set; }
        public virtual ICollection<AssetInLibrary> AssetInLibraries { get; set; }
        public string ImageUrls {
            get { return string.Join(',', _imageUrl); }
            set { _imageUrl = value.Split(',').ToList(); }
        } 
    }
}
