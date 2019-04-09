using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBooksList {
    public class BooksListViewModel {
        public IList<BookPreviewModel> CatalogPreviewModels { get; set; }
    }
}
