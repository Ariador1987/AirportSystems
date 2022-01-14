using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.CountryDTO
{
    public class CountryDTO
    {
        [Required]
        public string Name { get; set; }

    }
}
