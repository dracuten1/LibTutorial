using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models {
    public class CheckoutHistory {
        public int Id { get; set; }
        
        public LibraryAsset LibraryAsset { get; set; }

        public LibraryBranch LibraryBranch { get; set; }

        public LibraryCard LibraryCard { get; set; }

        
        public DateTime CheckedOut { get; set; }

        public DateTime? CheckedIn { get; set; }
    }
}
