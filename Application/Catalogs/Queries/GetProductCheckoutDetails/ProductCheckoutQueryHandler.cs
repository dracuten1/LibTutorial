using Application.Catalogs.Models;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetProductCheckoutDetails {
    public class ProductCheckoutPreviewQueryHandler : IRequestHandler<ProductCheckoutQuery, ProductCheckoutPreviewModel> {
        private readonly IWebDbContext _context;
        private readonly IMapper _mapper;

        public ProductCheckoutPreviewQueryHandler(IWebDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCheckoutPreviewModel> Handle(ProductCheckoutQuery request, CancellationToken cancellationToken) {
            //throw new System.Exception();
            return await _context.Products.ProjectTo<ProductCheckoutPreviewModel>(_mapper.ConfigurationProvider).SingleAsync(b => b.Id == request.Id, cancellationToken);    
        }
    }
}
