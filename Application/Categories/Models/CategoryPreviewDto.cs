using Application.Interfaces.Mapping;
using AutoMapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Categories.Models {
    public class CategoryPreviewDto:IHaveCustomMapping {


        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<CategoryPreviewDto> Children { get; set; }

        public void CreateMappings(Profile configuration) {
            configuration.CreateMap<AssetCategory, CategoryPreviewDto>()
                .ForMember(cDTO => cDTO.CategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.CategoryName, opt => opt.MapFrom(c => c.Name))
                .ForMember(cDTO => cDTO.Children, opt => opt.MapFrom(c => c.Children))
                ;
        }
    }
}
