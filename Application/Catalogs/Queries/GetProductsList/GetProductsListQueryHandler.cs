using Application.Catalogs.Models;
using Application.Infracstructure.PredicateBuilder.PredicateHelpers;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetProductsList {
    public class ProductCheckOutHandler : IRequestHandler<GetProductsListQuery, ProductsListViewDto> {
        private readonly IWebDbContext _context;
        private readonly IMapper _mapper;

        public ProductCheckOutHandler(IWebDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductsListViewDto> Handle(GetProductsListQuery request, CancellationToken cancellationToken) {
            var pre = new GetListProductsPredicate(request);

            var products = await _context.Products
                .Where(pre.Predicate())
                .ToListAsync(cancellationToken);
            return new ProductsListViewDto() {
                CatalogPreviewModels = _mapper.Map<IEnumerable<ProductPreviewDto>>(products).ToList()
            };
        }
    }
}
