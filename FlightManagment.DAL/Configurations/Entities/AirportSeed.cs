using FlightManagment.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.DAL.Configurations.Entities
{
    internal class AirportSeed : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasData(
                    new Airport
                    {
                        Id = 1,
                        Name = "Split",
                        CountryId = 1,
                        ConstructionDate = new DateTime(2014, 12, 01)

                    },
                    new Airport
                    {
                        Id = 2,
                        Name = "Palermo",
                        CountryId = 2,
                        ConstructionDate = new DateTime(2012, 03, 01)

                    },
                    new Airport
                    {
                        Id = 3,
                        Name = "Frankfurt",
                        CountryId = 3,
                        ConstructionDate = new DateTime(2017, 06, 01)

                    },
                    new Airport
                    {
                        Id = 4,
                        Name = "Ljubljana",
                        CountryId = 4,
                        ConstructionDate = new DateTime(2018, 07, 05)

                    },
                    new Airport
                    {
                        Id = 5,
                        Name = "Graz",
                        CountryId = 5,
                        ConstructionDate = new DateTime(2013, 04, 04)

                    },
                    new Airport
                    {
                        Id = 6,
                        Name = "Warsaw",
                        CountryId = 6,
                        ConstructionDate = new DateTime(2017, 03, 22)
                    }
                );
        }
    }
}
