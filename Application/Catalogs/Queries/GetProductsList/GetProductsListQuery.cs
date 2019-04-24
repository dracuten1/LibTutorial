using Application.Catalogs.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetProductsList {
    public class GetProductsListQuery:IRequest<ProductsListViewDto> {
        public int CategoryId { get; set; } = 0;
        
        public int LocationId { get; set; } = 0;
     
        //TO DO: get by genre
        //TO DO: get by Location
    }
}
