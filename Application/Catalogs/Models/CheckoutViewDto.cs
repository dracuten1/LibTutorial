using Application.Interfaces.Mapping;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Catalogs.Models {
    public class CheckoutViewDto : IHaveCustomMapping {
        public int Id { get; set; }
        public string PatronName { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public void CreateMappings(Profile configuration) {
            configuration.CreateMap<CheckoutHistory, CheckoutViewDto>()
                .ForMember(cDto => cDto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDto => cDto.PatronName, opt => opt.MapFrom(c => c.LibraryCard.Patron.FirstName))
                .ForMember(cDto => cDto.From, opt => opt.MapFrom(c => c.CheckedOut))
                .ForMember(cDto => cDto.To, opt => opt.MapFrom(c => c.CheckedIn));
        }
    }
}
