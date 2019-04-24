using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.Commands.Checkout {
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, Unit> {
        private readonly LibraryContext _context;

        public CheckoutCommandHandler(LibraryContext context) {
            _context = context;
        }
        public async Task<Unit> Handle(CheckoutCommand request, CancellationToken cancellationToken) {
            var ProductToCheckout = await _context.Products.SingleAsync(b => b.Id.Equals(request.CatalogId), cancellationToken);
            var libraryCardToCheckout = await _context.LibraryCards.SingleAsync(b => b.Id.Equals(request.PatronId), cancellationToken);
            var checkout = new CheckoutHistory() {
                //LibraryAsset = ProductToCheckout,
                LibraryCard = libraryCardToCheckout,
                CheckedOut = DateTime.Now
            };

            _context.CheckoutHistories.Add(checkout);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
