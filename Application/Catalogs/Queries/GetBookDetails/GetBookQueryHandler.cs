using Application.Catalogs.Queries.GetBookDetails.Models;
using Application.Catalogs.Queries.GetBooksList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetBookDetails {
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDetailViewDto> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDetailViewDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken) {
            var book = await _context.Books.Where(b=>b.Id==request.Id)
                .Include(b=>b.AssetType)
                .SingleAsync(cancellationToken);

            var bookDetailViewModel = _mapper.Map<IEnumerable<BookViewDto>>(book).FirstOrDefault();

            var checkOutHistoris = await _context.CheckoutHistories
                .Where(cH => cH.LibraryAsset.Id.Equals(bookDetailViewModel.Id))
                .Include(c => c.LibraryCard.Patron)
                .OrderByDescending(c=>c.CheckedIn).ToListAsync(cancellationToken);

            //var cH = await _context.CheckoutHistories().Tolist;
            var checkOutHistoryViewModels = _mapper.Map<IEnumerable<CheckoutViewDto>>(checkOutHistoris);
            var result = new BookDetailViewDto() {
                BookViewModel = bookDetailViewModel,
                CheckOutViewModelHistoris = checkOutHistoryViewModels
            };
            return result;
        }
    }
}