using Application.Catalogs.Queries.GetBookDetails.Models;
using MediatR;

namespace Application.Catalogs.Queries.GetBookDetails {
    public class GetBookDetailQuery: IRequest<BookDetailViewDto> {
        public int Id { get; set; }
    }
}
