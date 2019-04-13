using Application.Interfaces.Mapping;
using AutoMapper;
using Data.Models;

namespace Application.Catalogs.Queries.GetBookDetails.Models {
    public class BookLocationViewDto : IHaveCustomMapping {
        public string Location { get; set; }
        public int NumberOfCopies { get; set; }
        public void CreateMappings(Profile configuration) {
            configuration.CreateMap<LibraryAsset, BookLocationViewDto>()
                .ForMember(cDto => cDto.Location, opt => opt.MapFrom(lA => lA.Location.Address));
                //.ForMember(cDto => cDto.NumberOfCopies, opt => opt.ResolveUsing)

        }
    }
}