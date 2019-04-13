using Application.Infracstructure.AutoMapper.Converters;
using AutoMapper;
using System.Reflection;

namespace Application.Infracstructure.AutoMapper {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        private void LoadConverters() {
            //CreateMap<>
        }

        private void LoadStandardMappings() {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom) {
                CreateMap(map.Source, map.Destination).ReverseMap();
               // CreateMap(map.Source, map.Destination).ConvertUsing(GenreConverter);
                
            }
        }

        private void LoadCustomMappings() {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom) {
                map.CreateMappings(this);
            }
        }
    }
}
