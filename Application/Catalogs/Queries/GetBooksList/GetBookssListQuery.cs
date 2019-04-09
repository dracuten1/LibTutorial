using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBooksList {
    public class GetBookssListQuery:IRequest<BooksListViewModel> {
    }
}
