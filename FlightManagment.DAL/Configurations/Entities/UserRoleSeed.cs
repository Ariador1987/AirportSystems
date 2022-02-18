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
    public class UserRoleSeed : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "0468917c-e1a0-459c-a187-f964f3a28911",
                        UserId = "f5ee4379-a6b0-4350-9fed-6501306b7ff2"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "7e64a228-607e-4d71-aa2a-7c793358bdc0",
                        UserId = "332286ba-b449-4bce-8628-f148088fa0e6"
                    }
                );
        }
    }
}
