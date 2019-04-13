using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetBooksList {
    public class BookCheckOutHandler : IRequestHandler<GetBooksListQuery, BooksListViewDto> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookCheckOutHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BooksListViewDto> Handle(GetBooksListQuery request, CancellationToken cancellationToken) {
            return new BooksListViewDto() {
                CatalogPreviewModels = await _context.Books.ProjectTo<BookPreviewDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
