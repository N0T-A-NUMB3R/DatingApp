using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
               .ForMember(dest => dest.PhotoUrl, opt =>
               {
                   opt.MapFrom(src => src.Photos.FirstOrDefault(f => f.IsMain).Url);
               })
               .ForMember(dest => dest.Age, opt =>
               {
                   opt.MapFrom(src => src.DateOfBirth.CalculateAge());
               });

            CreateMap<User, UserForDetailedDTO>().ForMember(dest => dest.PhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(f => f.IsMain).Url);
            })
                           .ForMember(dest => dest.Age, opt =>
                           {
                               opt.MapFrom(src => src.DateOfBirth.CalculateAge());
                           });


            CreateMap<Photo, PhotosForDetailedDTO>();
        }
    }
}