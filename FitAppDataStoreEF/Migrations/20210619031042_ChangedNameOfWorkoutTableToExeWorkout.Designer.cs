﻿// <auto-generated />
using System;
using FitAppDataStoreEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitAppDataStoreEF.Migrations
{
    [DbContext(typeof(FitAppDbContext))]
    [Migration("20210619031042_ChangedNameOfWorkoutTableToExeWorkout")]
    partial class ChangedNameOfWorkoutTableToExeWorkout
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ExeWorkoutId")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasIndex("ExeWorkoutId");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoalNotes")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ExeWorkoutId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExeProgramExeProgramId", "ExeWorkoutExeWorkoutId");

                    b.HasIndex("ExeWorkoutId");

                    b.ToTable("ExeProgramWorkouts");
                });

            modelBuilder.Entity("FitAppModels.ExeWorkout", b =>
                {
                    b.Property<string>("ExeWorkoutId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoalNotes")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LibExeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set1Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set2Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set3Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set4Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set5Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set6Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set7Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set8Values")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Set9Values")
                        .HasColumnType("nvarchar(max)");

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
                            Id = "ff7d49d3-3e2f-449d-bf09-7b03858dd721",
                            ConcurrencyStamp = "6a4be15c-95f2-4da4-b28c-3e10c4f55d6f",
                            Name = "Athlete",
                            NormalizedName = "ATHLETE"
                        },
                        new
                        {
                            Id = "8ff485f4-01c9-4274-9410-14d534abee0b",
                            ConcurrencyStamp = "f30a80f9-8cb1-4aa0-a33b-e0013994c613",
                            Name = "Coach",
                            NormalizedName = "COACH"
                        },
                        new
                        {
                            Id = "f7f3cc2c-f5b4-4b61-9bc1-b01b71ac966e",
                            ConcurrencyStamp = "72fe5fcc-2ec8-46d1-a8f6-e4e69d876e11",
                            Name = "Head Coach",
                            NormalizedName = "HEAD COACH"
                        },
                        new
                        {
                            Id = "c9aba6a1-233c-4e01-b12b-0551a1120111",
                            ConcurrencyStamp = "5badfa23-41ad-424c-8dee-629b98ab9736",
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
                    b.HasOne("FitAppModels.ExeWorkout", "ExeWorkout")
                        .WithMany()
                        .HasForeignKey("ExeWorkoutId");

                    b.HasOne("FitAppModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("ExeWorkout");

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
                        .WithMany("ExeProgramWorkouts")
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.ExeWorkout", "ExeWorkout")
                        .WithMany("ExeProgramWorkouts")
                        .HasForeignKey("ExeWorkoutId");

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
                    b.Navigation("ExeProgramWorkouts");

                    b.Navigation("FitAppUserExePrograms");
                });

            modelBuilder.Entity("FitAppModels.ExeWorkout", b =>
                {
                    b.Navigation("ExeProgramWorkouts");
                });

            modelBuilder.Entity("FitAppModels.FitAppUser", b =>
                {
                    b.Navigation("FitAppUserExePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
