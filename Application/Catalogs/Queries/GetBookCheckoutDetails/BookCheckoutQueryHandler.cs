using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetBookCheckoutDetails {
    public class BookCheckoutPreviewQueryHandler : IRequestHandler<GetBookCheckoutPreviewQuery, BookCheckoutPreviewModel> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookCheckoutPreviewQueryHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookCheckoutPreviewModel> Handle(GetBookCheckoutPreviewQuery request, CancellationToken cancellationToken) {
            return await _context.Books.ProjectTo<BookCheckoutPreviewModel>(_mapper.ConfigurationProvider).SingleAsync(b => b.Id == request.Id, cancellationToken);    
        }
    }
}
