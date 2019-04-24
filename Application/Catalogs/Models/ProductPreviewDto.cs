using Application.Interfaces.Mapping;
using AutoMapper;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Catalogs.Models {
    public class ProductPreviewDto : IHaveCustomMapping {
        public int Id { get; set; }
        public string Title { get; set; }
        private string ImageUrl { get; set; }
        
        public List<string> ImgUrls {
            get {
                return ImageUrl.Split(',').ToList();
            }
        }
        public virtual void CreateMappings(Profile configuration) {
            configuration.CreateMap<Product, ProductPreviewDto>()              
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(cDTO => cDTO.ImageUrl, opt => opt.MapFrom(c => c.ImageUrls))
                ;
        }
    }
}
