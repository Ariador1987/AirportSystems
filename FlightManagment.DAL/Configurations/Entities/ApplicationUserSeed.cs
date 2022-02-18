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
    public class ApplicationUserSeed : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "332286ba-b449-4bce-8628-f148088fa0e6",
                        Email = "admin@as.com",
                        NormalizedEmail = "ADMIN@AS.COM",
                        UserName = "admin@as.com",
                        NormalizedUserName = "ADMIN@AS.COM",
                        FirstName = "system",
                        LastName = "admin",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    },
                    new ApplicationUser
                    {
                        Id = "f5ee4379-a6b0-4350-9fed-6501306b7ff2",
                        Email = "checker@as.com",
                        NormalizedEmail = "CHECKER@AS.COM",
                        UserName = "checker@as.com",
                        NormalizedUserName = "CHECKER@AS.COM",
                        FirstName = "system",
                        LastName = "checker",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1")
                    }
                );
        }
    }
}
