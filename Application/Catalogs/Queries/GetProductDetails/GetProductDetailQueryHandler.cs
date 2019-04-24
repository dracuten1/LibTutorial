using Application.Catalogs.Models;
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetProductDetails {
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailViewDto> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailViewDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken) {
            var Product = await _context.Products.Where(b => b.Id == request.Id)
                .Include(b => b.AssetCategory.OrtherAttributes)
                .SingleAsync(cancellationToken);

            var ProductDetailViewModel = _mapper.Map<ProductViewDto>(Product);

            var checkOutHistoris = await _context.CheckoutHistories              
                .Include(c => c.LibraryCard.Patron)
                .OrderByDescending(c => c.CheckedIn)
                .ToListAsync(cancellationToken);

            //var cH = await _context.CheckoutHistories().Tolist;
            var checkOutHistoryViewModels = _mapper.Map<IEnumerable<CheckoutViewDto>>(checkOutHistoris);
            var result = new ProductDetailViewDto() {
                ProductViewModel = ProductDetailViewModel,
                CheckOutViewModelHistoris = checkOutHistoryViewModels
            };
            return result;
        }
    }
}