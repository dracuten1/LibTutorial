using System;
using System.Collections.Generic;

namespace Domain.Models {
    public class AssetCategory {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategoryAttribute> OrtherAttributes { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public AssetCategory Parent { get; set; }
        public virtual ICollection<AssetCategory> Children { get; set; }

        public override bool Equals(object obj) {
            var ortherAssetType = obj as AssetCategory;
            return Id==ortherAssetType.Id;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Id, Name, Description);
        }
    }
}
