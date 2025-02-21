using AutoMapper;
using DataAccessLayer.Entity;
using DTO;

namespace CabHiringSystem.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)).ReverseMap();
            
        }
    }
}
