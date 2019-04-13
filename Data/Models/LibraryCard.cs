using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models {
    public class LibraryCard {
        [Display(Name = "Overdue Fees")]
        public decimal Fees { get; set; }

        [Display(Name = "Card Issued Date")]
        public DateTime Created { get; set; }

        [Display(Name = "Materials on Loan")]
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
        [Key]
        [ForeignKey("Patron")]
        public int Id { get; set; }
        public virtual Patron Patron { get; set; }
    }
}
