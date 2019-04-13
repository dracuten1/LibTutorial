using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBooksList {
    public class GetBooksListQuery:IRequest<BooksListViewDto> {
        //TO DO: get by genre
        //TO DO: get by Location
    }
}
