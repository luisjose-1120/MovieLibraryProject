using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DataAccessLayer.DataObject;

namespace API.BE.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Actor, Models.Actor>().ReverseMap();
            CreateMap<data.Director, Models.Director>().ReverseMap();
            CreateMap<data.Genre, Models.Genre>().ReverseMap();
            CreateMap<data.Movie, Models.Movie>().ReverseMap();
            CreateMap<data.MovieActor, Models.MovieActor>().ReverseMap();
            CreateMap<data.MovieGenre, Models.MovieGenre>().ReverseMap();
            CreateMap<data.Production, Models.Production>().ReverseMap();
        }
    }
}
