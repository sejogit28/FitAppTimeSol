﻿// <auto-generated />
using System;
using FitAppDataStoreEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitAppDataStoreEF.Migrations
{
    [DbContext(typeof(FitAppDbContext))]
    partial class FitAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitAppModels.Exe", b =>
                {
                    b.Property<int>("ExeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EachSide")
                        .HasColumnType("bit");

                    b.Property<string>("ExeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExeNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExeWorkoutExeWorkoutId")
                        .HasColumnType("int");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<string>("Rest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("Tempo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutGroupOrder")
                        .HasColumnType("int");

                    b.HasKey("ExeId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("Exe");
                });

            modelBuilder.Entity("FitAppModels.ExeProgram", b =>
                {
                    b.Property<int>("ExeProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Goal")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("GoalNotes")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ExeProgramId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("ExeProgram");
                });

            modelBuilder.Entity("FitAppModels.ExeProgramWorkouts", b =>
                {
                    b.Property<int>("ExeProgramExeProgramId")
                        .HasColumnType("int");

                    b.Property<int>("ExeWorkoutExeWorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExeProgramExeProgramId", "ExeWorkoutExeWorkoutId");

                    b.HasIndex("ExeWorkoutExeWorkoutId");

                    b.ToTable("ExeProgramWorkouts");
                });

            modelBuilder.Entity("FitAppModels.ExeWorkout", b =>
                {
                    b.Property<int>("ExeWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoalNotes")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ExeWorkoutId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("ExeWorkout");
                });

            modelBuilder.Entity("FitAppModels.FitAppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FitAppModels.FitAppUserExePrograms", b =>
                {
                    b.Property<int>("ExeProgramExeProgramId")
                        .HasColumnType("int");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExeProgramExeProgramId", "FitAppUserId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("FitAppUserExePrograms");
                });

            modelBuilder.Entity("FitAppModels.LibExe", b =>
                {
                    b.Property<int>("LibExeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("EachSide")
                        .HasColumnType("bit");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LibExeName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("LibExeId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("LibExe");
                });

            modelBuilder.Entity("FitAppModels.UserExeValues", b =>
                {
                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExeExeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnteredValuesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Set10Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set1Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set2Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set3Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set4Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set5Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set6Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set7Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set8Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Set9Values")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FitAppUserId", "ExeExeId", "EnteredValuesDate");

                    b.HasIndex("ExeExeId");

                    b.ToTable("UserExeValues");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "4efac84d-6449-4675-aed3-f82d18012692",
                            ConcurrencyStamp = "e7240151-a58a-4878-8ff3-8e6ccc2a66ff",
                            Name = "Athlete",
                            NormalizedName = "ATHLETE"
                        },
                        new
                        {
                            Id = "851f1862-525a-4b7d-9d2f-238e449540fb",
                            ConcurrencyStamp = "e692368e-e167-4ad1-8a33-ce9804f41767",
                            Name = "Coach",
                            NormalizedName = "COACH"
                        },
                        new
                        {
                            Id = "b45a780c-a39b-4554-bfe2-ef52a0199af8",
                            ConcurrencyStamp = "fee90aba-4d0b-48ec-a1bf-50822b9e671b",
                            Name = "Head Coach",
                            NormalizedName = "HEAD COACH"
                        },
                        new
                        {
                            Id = "ebe2d5cd-ae9a-4aec-a083-7a3ba0475fe3",
                            ConcurrencyStamp = "540a6bf3-427e-4694-9b49-4e285e5768d1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FitAppModels.Exe", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.ExeProgram", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.ExeProgramWorkouts", b =>
                {
                    b.HasOne("FitAppModels.ExeProgram", "ExeProgram")
                        .WithMany()
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.ExeWorkout", "ExeWorkout")
                        .WithMany()
                        .HasForeignKey("ExeWorkoutExeWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeProgram");

                    b.Navigation("ExeWorkout");
                });

            modelBuilder.Entity("FitAppModels.ExeWorkout", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.FitAppUserExePrograms", b =>
                {
                    b.HasOne("FitAppModels.ExeProgram", "ExeProgram")
                        .WithMany("FitAppUserExePrograms")
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany("FitAppUserExePrograms")
                        .HasForeignKey("FitAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeProgram");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.LibExe", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.UserExeValues", b =>
                {
                    b.HasOne("FitAppModels.Exe", "Exe")
                        .WithMany()
                        .HasForeignKey("ExeExeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exe");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FitAppModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitAppModels.ExeProgram", b =>
                {
                    b.Navigation("FitAppUserExePrograms");
                });

            modelBuilder.Entity("FitAppModels.FitAppUser", b =>
                {
                    b.Navigation("FitAppUserExePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
