using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models {
    public class Patron {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Telephone { get; set; }
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Library Card")]
        public virtual LibraryCard LibraryCard { get; set; }
        public LibraryBranch HomeLibraryBranch { get; set; }
    }
}
