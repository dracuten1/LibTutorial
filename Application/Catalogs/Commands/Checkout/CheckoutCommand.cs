using MediatR;

namespace Application.Catalogs.Commands.Checkout {
    public class CheckoutCommand: IRequest {
        public int CatalogId { get; set; }
        public int PatronId { get; set; }
    }
}
