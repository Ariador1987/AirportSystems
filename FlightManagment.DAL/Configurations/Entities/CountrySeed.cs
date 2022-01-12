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
    internal class CountrySeed : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                    new Country
                    {
                        Id = 1,
                        Name = "Croatia"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "Italy"
                    },
                    new Country
                    {
                        Id = 3,
                        Name = "Germany"
                    },
                    new Country
                    {
                        Id = 4,
                        Name = "Slovenia"
                    },
                    new Country
                    {
                        Id = 5,
                        Name = "Austria"
                    },
                    new Country
                    {
                        Id = 6,
                        Name = "Poland"
                    }
                );
        }
    }
}
