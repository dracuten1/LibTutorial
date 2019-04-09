using Application.Catalogs.Queries.GetBooksList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBookDetails.Models {
    public class BookDetailViewModel {
        public BookViewModel BookViewModel { get; set; }
        public IEnumerable<CheckoutViewModel> CheckOutViewModelHistoris { get; set; }
    }
}
