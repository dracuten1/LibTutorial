using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetBooksList {
    public class GetBooksListQueryHandler : IRequestHandler<GetBookssListQuery, BooksListViewModel> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetBooksListQueryHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BooksListViewModel> Handle(GetBookssListQuery request, CancellationToken cancellationToken) {
            return new BooksListViewModel() {
                CatalogPreviewModels = await _context.Books.ProjectTo<BookPreviewModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
