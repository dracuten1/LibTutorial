using Application.Categories.Queries;
using Application.Interfaces.Predicate;
using Data.Models;
using System;
using System.Linq.Expressions;

namespace Application.Infracstructure.PredicateBuilder.PredicateHelpers {
    public class CategoryPredicate : APredicateHelper<AssetCategory> {
        public CategoryPredicate(GetCategoryQuery request) {
            if (request.CategoryId == 0) {
                predicate = predicate.And(c => c.Parent == null);
            }
            else {
                predicate = predicate.And(c => c.Id == request.CategoryId);
            }
        }
    }
}
