using Application.Categories.Models;
using Application.Infracstructure.PredicateBuilder.PredicateHelpers;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries {
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, ListCategoriesDto> {
        private readonly IWebDbContext libraryContext;
        private readonly IMapper mapper;

        public GetCategoryHandler(IWebDbContext libraryContext, IMapper mapper) {
            this.libraryContext = libraryContext;
            this.mapper = mapper;
        }
        public async Task<ListCategoriesDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken) {
            var predicate = new CategoryPredicate(request);

            var categories = await libraryContext.AssetCategories.Where(predicate.Predicate()).Include(c => c.Children).ThenInclude(it=>it.Children).ToListAsync(cancellationToken);
            return new ListCategoriesDto() {
                CategoryPreviewDtos = mapper.Map<List<CategoryPreviewDto>>(categories),
        };
        }
    }
}
