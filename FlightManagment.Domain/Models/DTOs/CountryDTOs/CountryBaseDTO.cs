﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Domain.Models.DTOs.CountryDTO
{
    public class CountryBaseDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }
}