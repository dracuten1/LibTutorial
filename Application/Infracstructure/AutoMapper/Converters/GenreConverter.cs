using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infracstructure.AutoMapper.Converters {
    public class GenreConverter : ITypeConverter<IEnumerable<Genre>,List<string>> {
        public List<string> Convert(IEnumerable<Genre> source, List<string> destination, ResolutionContext context) {
            var lstGenre = new List<string>();
            foreach (var genre in source) {
                lstGenre.Add(genre.Name);
            }
            return lstGenre;
        }
    }
}
