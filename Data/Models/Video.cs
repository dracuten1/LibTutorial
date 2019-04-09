using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class Video : LibraryAsset {
        [Required]
        public string Director { get; set; }
    }
}
