using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.CountryDTOs
{
    public class CountryDetailsDTO
    {
        public int Name { get; set; }
        public IList<AirportBaseDTO> Airports { get; set; }
    }
}
