using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models {
    public class StatusServiceModel {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}