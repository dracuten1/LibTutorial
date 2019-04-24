using System.Collections.Generic;

namespace Application.Catalogs.Models {
    public class ProductDetailViewDto {
        public ProductViewDto ProductViewModel { get; set; }
        public IEnumerable<CheckoutViewDto> CheckOutViewModelHistoris { get; set; }
        public IEnumerable<ProductLocationViewDto> ProductLocationViewModels { get; set; }
    }
}
