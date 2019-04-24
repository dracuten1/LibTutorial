using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Models {
    public class ProductsListViewDto {
        public IList<ProductPreviewDto> CatalogPreviewModels { get; set; }
    }
}
