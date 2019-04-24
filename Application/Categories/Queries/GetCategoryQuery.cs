using Application.Categories.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Categories.Queries {
    public class GetCategoryQuery:IRequest<ListCategoriesDto> {
        public int CategoryId { get; set; } = 0;      
    }
}
