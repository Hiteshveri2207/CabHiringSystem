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

            CreateMap<CustomerProfile, CustomerDTO>().ReverseMap();

            CreateMap<DriverProfile, DriverProfileDTO>()
            .ReverseMap();

            CreateMap<State, VehicleImageDTO>().ReverseMap();
            
            CreateMap<Country, CountryDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<Brand, BrandDTO>().ReverseMap();

            CreateMap<DriverVehicleDTO, DriverVehicle>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
            ReverseMap();


            CreateMap<VehicleImage, VehicleImageDTO>().ReverseMap();

            CreateMap<Car, CarDTO>().ReverseMap();

            CreateMap<CarColor, CarColorDTO>().ReverseMap();

        }
    }
}
