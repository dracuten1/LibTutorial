using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models {
    public class LibraryCard {
        public decimal Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
        [Key]
        [ForeignKey("Patron")]
        public int Id { get; set; }
        public virtual Patron Patron { get; set; }
    }
}
