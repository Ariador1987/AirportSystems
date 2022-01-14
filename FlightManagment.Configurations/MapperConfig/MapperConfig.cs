﻿using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using FlightManagment.Domain.Models.DTOs.CountryDTO;
using FlightManagment.Domain.Models.DTOs.CountryDTOs;
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
            CreateMap<Airport, AirportBaseDTO>().ReverseMap();
            CreateMap<Airport, AirportCreateDTO>().ReverseMap();
            CreateMap<Airport, AirportUpdateDTO>().ReverseMap();

            CreateMap<Country, CountryBaseDTO>().ReverseMap();
            CreateMap<Country, CountryUpdateDTO>().ReverseMap();
            CreateMap<Country, CountryDetailsDTO>().ReverseMap();
        }
    }
}
