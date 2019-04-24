using Application.Catalogs.Models;
using MediatR;

namespace Application.Catalogs.Queries.GetProductDetails {
    public class GetProductDetailQuery: IRequest<ProductDetailViewDto> {
        public int Id { get; set; }
    }
}
