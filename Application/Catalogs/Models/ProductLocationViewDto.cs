using Application.Interfaces.Mapping;
using AutoMapper;
using Data.Models;

namespace Application.Catalogs.Models {
    public class ProductLocationViewDto : IHaveCustomMapping {
        public string Location { get; set; }
        public int NumberOfCopies { get; set; }
        public void CreateMappings(Profile configuration) {
            configuration.CreateMap<AssetInLibrary, ProductLocationViewDto>()
                .ForMember(cDto => cDto.Location, opt => opt.MapFrom(lA => lA.Location.Address));
                //.ForMember(cDto => cDto.NumberOfCopies, opt => opt.ResolveUsing)

        }
    }
}