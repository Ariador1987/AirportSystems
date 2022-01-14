using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Configurations.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Airport, AirportCreateDTO>().ReverseMap();
            CreateMap<Airport, AirportUpdateDTO>().ReverseMap();
        }
    }
}
