using Application.Interfaces.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.Catalogs.Models {
    public class ProductCheckoutPreviewModel:IHaveCustomMapping {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Retain { get; set; }

        public virtual void CreateMappings(Profile configuration) {
            configuration.CreateMap<Product, ProductCheckoutPreviewModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title))
                .ForMember(cDTO => cDTO.ImageUrl, opt => opt.MapFrom(c => c.ImageUrls));
        }
    }
}
