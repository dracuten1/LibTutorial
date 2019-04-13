using Application.Catalogs.Queries.GetBooksList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBookDetails.Models {
    public class BookDetailViewDto {
        public BookViewDto BookViewModel { get; set; }
        public IEnumerable<CheckoutViewDto> CheckOutViewModelHistoris { get; set; }
        public IEnumerable<BookLocationViewDto> BookLocationViewModels { get; set; }
    }
}
