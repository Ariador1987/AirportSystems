using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Iata Code has to be exactly six characters.")]
        [Display(Name = "IataCode")]
        public string FlightNumber { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy. HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FlightDate { get; set; }
        [StringLength(255)]
        public string? FlightTime { get; set;}
        [StringLength(255)]
        public string? Carrier { get; set; }
        [StringLength(255)]
        public string? AirportTo { get; set; }
        // NavProps
        public int? AirportId { get; set; }
        [ForeignKey(nameof(AirportId))]
        public Airport Airport { get; set; }
    }
}
