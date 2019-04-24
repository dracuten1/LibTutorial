using Application.Catalogs.Queries.GetProductsList;
using Application.Interfaces.Predicate;
using Domain.Models;

namespace Application.Infracstructure.PredicateBuilder.PredicateHelpers {
    public class GetListProductsPredicate: APredicateHelper<Product> {
        public GetListProductsPredicate(GetProductsListQuery request) {
            if (request.CategoryId != 0) {
                predicate = predicate.And(c => c.AssetCategory.Id == request.CategoryId);
            };
            if (request.LocationId != 0) {
                //predicate = predicate.And(c => c.AssetCategory.Id == request.CategoryId);
            }
        }
    }
}
