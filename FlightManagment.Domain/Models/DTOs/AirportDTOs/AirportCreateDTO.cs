using FlightManagment.Domain.Models.DTOs.CountryDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.AirportDTOs
{
    public class AirportCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime? ConstructionDate { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
