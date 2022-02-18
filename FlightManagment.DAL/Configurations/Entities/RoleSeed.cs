using FlightManagment.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.DAL.Configurations.Entities
{
    public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "0468917c-e1a0-459c-a187-f964f3a28911",
                        Name = "Checker",
                        NormalizedName = "CHECKER",
                    },
                    new IdentityRole
                    {
                        Id = "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                        Name = "Admin",
                        NormalizedName = "ADMIN",
                    }
                ); 
        }
    }
}
