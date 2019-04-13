using Application.Catalogs.Queries.GetBooksList;
using Application.Interfaces.Mapping;
using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBookDetails.Models {
    public class BookViewDto : BookPreviewDto {
        public string Type { get; set; }
        public int Year { get; set; }
        public string Isbn { get; set; }
        public string Dewey { get; set; }
        public List<string> Genres { get; set; }
        public decimal Cost { get; set; }

        public override void CreateMappings(Profile configuration) {
            configuration.CreateMap<Book, BookViewDto>()
                .IncludeBase<Book, BookPreviewDto>()
                .ForMember(cDTO => cDTO.Year, opt => opt.MapFrom(b => b.Year))
                .ForMember(cDTO => cDTO.Isbn, opt => opt.MapFrom(b => b.ISBN))
                .ForMember(cDTO => cDTO.Cost, opt => opt.MapFrom(b => b.Cost))
                .ForMember(cDTO => cDTO.Dewey, opt => opt.MapFrom(b => b.DeweyIndex))               
                .ForMember(cDTO => cDTO.Type, opt => opt.MapFrom(b => b.AssetType.Name))
                .ForMember(cDTO => cDTO.Genres, opt => opt.MapFrom(b => b.Genres))           
                ;
        }
    }
}
