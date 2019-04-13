using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class Video : Asset {
        public string Director { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
