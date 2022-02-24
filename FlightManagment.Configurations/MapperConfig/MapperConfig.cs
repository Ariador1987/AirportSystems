using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using FlightManagment.Domain.Models.DTOs.CountryDTO;
using FlightManagment.Domain.Models.DTOs.CountryDTOs;
using FlightManagment.Domain.Models.DTOs.FlightDTOs;
using FlightManagment.Domain.Models.DTOs.PassengerDTOs;
using FlightManagment.Domain.Models.DTOs.UserDTOs;

namespace FlightManagment.Configurations.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Airport, AirportBaseDTO>().ReverseMap();
            CreateMap<Airport, AirportCreateDTO>().ReverseMap();
            CreateMap<Airport, AirportUpdateDTO>().ReverseMap();
            CreateMap<Airport, AirportDetailsDTO>().ReverseMap();
            CreateMap<AirportBaseDTO, AirportUpdateDTO>().ReverseMap();

            CreateMap<Country, CountryBaseDTO>().ReverseMap();
            CreateMap<Country, CountryUpdateDTO>().ReverseMap();
            CreateMap<Country, CountryDetailsDTO>().ReverseMap();
            CreateMap<CountryBaseDTO, CountryUpdateDTO>().ReverseMap();

            CreateMap<Flight, FlightBaseDTO>().ReverseMap();
            CreateMap<Flight, FlightCreateDTO>().ReverseMap();
            CreateMap<Flight, FlightUpdateDTO>().ReverseMap();
            CreateMap<Flight, FlightDetailsDTO>().ReverseMap();

            CreateMap<Passenger, PassengerBaseDTO>().ReverseMap();

            CreateMap<ApplicationUser, RegisterUserDTO>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDTO>().ReverseMap();

        }
    }
}
