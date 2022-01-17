using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.FlightDTOs
{
    public class FlightDetailsDTO
    {
        [Display(Name = "IataCode")]
        public string FlightNumber { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy. HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FlightDate { get; set; }
        public string? FlightTime { get; set; }
        public string? Carrier { get; set; }
        public string? AirportTo { get; set; }
        // NavProps
        public int? AirportId { get; set; }
        public AirportDetailsDTO Airport { get; set; }
    }
}
