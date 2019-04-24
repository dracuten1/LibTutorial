using System;

namespace Data.Models {
    public class CategoryAttribute {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueSystemType { get; set; }

        public virtual AssetCategory AssetCategory { get; set; }
    }
}