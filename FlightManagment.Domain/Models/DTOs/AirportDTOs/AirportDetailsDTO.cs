using FlightManagment.Domain.Models.DTOs.CountryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.AirportDTOs
{
    public class AirportDetailsDTO
    {
        public string Name { get; set; }
        
        public DateTime? ConstructionDate { get; set; }
        //public IList<Flight> Flights { get; set; }
        // NavProps
        public int CountryId { get; set; }
        public CountryBaseDTO Country { get; set; }

    }
}
