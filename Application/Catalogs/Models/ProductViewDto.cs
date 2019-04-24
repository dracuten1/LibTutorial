using Application.Catalogs.Queries.GetProductsList;
using Application.Interfaces.Mapping;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Catalogs.Models {
    public class ProductViewDto : ProductPreviewDto {
        public string Type { get; set; }
        public int Year { get; set; }
        public string Dewey { get; set; }
        public List<string> Genres { get; set; }
        public decimal Cost { get; set; }

        public override void CreateMappings(Profile configuration) {
            configuration.CreateMap<Product, ProductViewDto>()
                .IncludeBase<Product, ProductPreviewDto>()
                .ForMember(cDTO => cDTO.Year, opt => opt.MapFrom(b => b.Year))              
                .ForMember(cDTO => cDTO.Cost, opt => opt.MapFrom(b => b.Cost))
                .ForMember(cDTO => cDTO.Type, opt => opt.MapFrom(b => b.AssetCategory.Name))
                //.ForMember(cDTO => cDTO.Genres, opt => opt.MapFrom(b => b.GenreProduct.Select(gb=>gb.Genre.Name).ToList()))
            ;
        }
    }
}
