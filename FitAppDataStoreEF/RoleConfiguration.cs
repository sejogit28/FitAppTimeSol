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
                    /*A Coach who signs up for free, can't make or do anything unless they get added  to
                     * an organization*/ 
                    Name = "Coach",
                    NormalizedName = "COACH"
                },
                 new IdentityRole
                 {
                     /*A Coach who signs up for "Tier 1", can do things outside of a bigger org(because they 
                      * have their own but has a pretty low athlete limit(75). Must be the only coach in their
                      * org*/
                     Name = "Level 1 Organization",
                     NormalizedName = "LEVEL 1 ORGANIZATION"
                 },

                 new IdentityRole
                 {
                     /*A Coach who signs up for "Tier 2", is most likely purchasing for themselves while working as
                      * part of a smaller college or purchasing for a decent sized facility. Has a respectable
                      * athlete limit(150), and can add 2 other coaches to their organization */
                     Name = "Level 2 Organization",
                     NormalizedName = "LEVEL 2 ORGANIZATION"
                 },

                 new IdentityRole
                 {
                     /*A Coach who signs up "Tier 3", is most likely purchasing for their entire S&C team as part
                      * of a college or works for a large facility. Has great athlete limit(300), and can add 4 other
                      * coaches to their organization */
                     Name = "Level 3 Organization",
                     NormalizedName = "LEVEL 3 LARGE ORGANIZATION"
                 },

                 new IdentityRole
                 {
                     /*A Coach who signs up for "Tier 4", is most likely a part of a larger college or facility, 
                      * has a sizable athlete limit(500), and can add 8 other coaches to their organization */
                     Name = "Level 4 Organization",
                     NormalizedName = "LEVEL 4 ORGANIZATION"
                 }, 
                 
                 new IdentityRole
                 {
                     /*A Coach who signs up for "Tier 5", is most likely a part of a premier college or facility, 
                      * has a sizable athlete limit(800), and can add 15 other coaches to their organization */
                     Name = "Level 5 Organization",
                     NormalizedName = "LEVEL 5 ORGANIZATION"
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
