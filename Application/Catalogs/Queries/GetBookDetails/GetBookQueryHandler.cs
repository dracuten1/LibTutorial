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
    public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDetailViewModel> {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryHandler(LibraryContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDetailViewModel> Handle(GetBookDetailQuery request, CancellationToken cancellationToken) {
            var books = await _context.Books.Where(b=>b.Id==request.Id)
                .Include(b=>b.AssetType)
                .Include(b=>b.Location)
                .Include(b=>b.Status)
                .ToListAsync(cancellationToken);
            var bookDetailViewModel = _mapper.Map<IEnumerable<BookViewModel>>(books).FirstOrDefault();
            var checkOutHistoris = await _context.CheckoutHistories.Where(cH => cH.LibraryAsset.Id.Equals(bookDetailViewModel.Id))
                .Include(c=>c.LibraryCard.Patron)
                .OrderByDescending(c=>c.CheckedIn).ToListAsync(cancellationToken);
            var checkOutHistoryViewModels = _mapper.Map<IEnumerable<CheckoutViewModel>>(checkOutHistoris);
            var result = new BookDetailViewModel() {
                BookViewModel = bookDetailViewModel,
                CheckOutViewModelHistoris = checkOutHistoryViewModels
            };
            return result;
        }
    }
}