using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FitAppDataStoreEF
{
    class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Athlete",
                    NormalizedName = "ATHLETE"
                },
                new IdentityRole
                {
                    Name = "Coach",
                    NormalizedName = "COACH"
                },
                 new IdentityRole
                 {
                     Name = "Head Coach",
                     NormalizedName = "HEAD COACH"
                 },
                  new IdentityRole
                  {
                      Name = "Administrator",
                      NormalizedName = "ADMINISTRATOR"
                  }
            );
        }
    }
}
