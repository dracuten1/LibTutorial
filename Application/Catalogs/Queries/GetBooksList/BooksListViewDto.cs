using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBooksList {
    public class BooksListViewDto {
        public IList<BookPreviewDto> CatalogPreviewModels { get; set; }
    }
}
