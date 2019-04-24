using Application.Catalogs.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetProductCheckoutDetails {
    public class ProductCheckoutQuery:IRequest<ProductCheckoutPreviewModel> {
        public int Id { get; set; }
    }
}
