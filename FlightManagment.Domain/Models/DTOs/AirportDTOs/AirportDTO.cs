using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.AirportDTOs
{
    public class AirportDTO
    {
        public string Name { get; set; }
        public DateTime? ConstructionDate { get; set; }
    }
}
