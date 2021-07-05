using FitAppModels;
using FitAppModels.BaseModels;
using FitAppModels.MTMModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitAppDataStoreEF
{
    public class FitAppDbContext : IdentityDbContext<FitAppUser>
    {
        public FitAppDbContext(DbContextOptions<FitAppDbContext> options)
            : base(options)
        {

        }

        //Base Tables
        public DbSet<FitAppUser> FitAppUser { get; set; }
        public DbSet<Exe> Exe { get; set; }
        public DbSet<LibExe> LibExe { get; set; }
        public DbSet<ExeProgram> ExeProgram { get; set; }
        public DbSet<ExeWorkout> ExeWorkout { get; set; }
        public DbSet<Organizations> Organizations { get; set; }

        //MtM Tables
        public DbSet<OrganizationFitAppUsers> OrganizationFitAppUsers { get; set; }
        public DbSet<OrganizationExePrograms> OrganizationExePrograms { get; set; }
        public DbSet<OrganizationExeWorkouts> OrganizationExeWorkouts { get; set; }
        public DbSet<FitAppUserExePrograms> FitAppUserExePrograms { get;set; }
        public DbSet<ExeProgramWorkouts> ExeProgramWorkouts { get; set; }
        public DbSet<UserExeValues> UserExeValues { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<FitAppUserExePrograms>()
            .HasKey(o => new { o.ExeProgramExeProgramId, o.FitAppUserId });

            builder.Entity<ExeProgramWorkouts>()
            .HasKey(o => new { o.ExeProgramExeProgramId, o.ExeWorkoutExeWorkoutId });

            builder.Entity<OrganizationFitAppUsers>()
            .HasKey(o => new { o.OrganizationsOrganizationId, o.FitAppUserId });

            builder.Entity<OrganizationExeWorkouts>()
            .HasKey(o => new { o.OrganizationsOrganizationId, o.ExeWorkoutExeWorkoutId });

            builder.Entity<OrganizationExePrograms>()
            .HasKey(o => new { o.OrganizationsOrganizationId, o.ExeProgramExeProgramId });

            builder.Entity<UserExeValues>()
            .HasKey(o => new { o.FitAppUserId, o.ExeExeId, o.EnteredValuesDate });
        }

    }
}
