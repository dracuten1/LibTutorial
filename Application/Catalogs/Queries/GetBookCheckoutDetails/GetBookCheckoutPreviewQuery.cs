using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBookCheckoutDetails {
    public class GetBookCheckoutPreviewQuery:IRequest<BookCheckoutPreviewModel> {
        public int Id { get; set; }
    }
}
