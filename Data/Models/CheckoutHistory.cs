﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models {
    public class CheckoutHistory {
        public int Id { get; set; }
        
        public AssetInLibrary LibraryAsset { get; set; }

        public LibraryCard LibraryCard { get; set; }

        
        public DateTime CheckedOut { get; set; }

        public DateTime? CheckedIn { get; set; }
    }
}
