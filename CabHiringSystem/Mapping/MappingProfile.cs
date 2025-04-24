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

            CreateMap<CustomerProfile, CustomerResponseDTO>();

              CreateMap<DriverProfile, DriverProfileDTO>().ReverseMap();

              CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<State, StateDTO>().ReverseMap();


            CreateMap<Country, CountryDTO>().ReverseMap();   

            CreateMap<Brand, BrandDTO>().ReverseMap();

            CreateMap<DriverVehicleDTO, DriverVehicle>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
            ReverseMap();
           
            CreateMap<VehicleImage, VehicleImageDTO>().ReverseMap();

            CreateMap<Car, CarDTO>().ReverseMap();

            CreateMap<CarColor, CarColorDTO>().ReverseMap();

            CreateMap<Booking, BookingDTO>().ReverseMap();

            CreateMap<Booking, BookingResponseDTO>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer != null && src.Customer.User != null ? src.Customer.User.FirstName + " " + src.Customer.User.LastName
            : string.Empty))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        }
    }
}
