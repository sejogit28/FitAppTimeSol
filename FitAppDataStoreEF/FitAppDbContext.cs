using FitAppModels;
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

        public DbSet<FitAppUser> FitAppUser { get; set; }
        public DbSet<Exe> Exe { get; set; }
        public DbSet<LibExe> LibExe { get; set; }
        public DbSet<ExeProgram> ExeProgram { get; set; }
        public DbSet<ExeWorkout> ExeWorkout { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<FitAppUserExePrograms>()
            .HasKey(o => new { o.ExeProgramExeProgramId, o.FitAppUserId });

            builder.Entity<ExeProgramWorkouts>()
            .HasKey(o => new { o.ExeProgramExeProgramId, o.ExeWorkoutExeWorkoutId });

            builder.Entity<UserExeValues>()
            .HasKey(o => new { o.FitAppUserId, o.ExeExeId, o.EnteredValuesDate });
        }

    }
}
