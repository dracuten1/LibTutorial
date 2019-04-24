using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class Video : AssetCategory {
        public string Director { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
