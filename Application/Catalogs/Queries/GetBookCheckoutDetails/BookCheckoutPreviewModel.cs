using Application.Interfaces.Mapping;
using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Queries.GetBookCheckoutDetails {
    public class BookCheckoutPreviewModel:IHaveCustomMapping {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Retain { get; set; }

        public virtual void CreateMappings(Profile configuration) {
            configuration.CreateMap<Book, BookCheckoutPreviewModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(cDTO => cDTO.ImageUrl, opt => opt.MapFrom(c => c.ImageUrl));
        }
    }
}
