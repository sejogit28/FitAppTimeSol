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
    [Migration("20210704143614_changedRoleNamesToBetterFitWithBackend")]
    partial class changedRoleNamesToBetterFitWithBackend
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitAppModels.BaseModels.Exe", b =>
                {
                    b.Property<int>("ExeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EachSide")
                        .HasColumnType("bit");

                    b.Property<string>("ExeName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ExeNotes")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ExeWorkoutExeWorkoutId")
                        .HasColumnType("int");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Rest")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<string>("Tempo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutGroup")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("WorkoutGroupOrder")
                        .HasColumnType("int");

                    b.HasKey("ExeId");

                    b.HasIndex("ExeWorkoutExeWorkoutId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("Exe");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeProgram", b =>
                {
                    b.Property<int>("ExeProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExeProgramTitle")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GoalNotes")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ExeProgramId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("ExeProgram");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeWorkout", b =>
                {
                    b.Property<int>("ExeWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExeWorkoutTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GoalNotes")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("ExeWorkoutId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("ExeWorkout");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.FitAppUser", b =>
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

            modelBuilder.Entity("FitAppModels.BaseModels.LibExe", b =>
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

                    b.Property<string>("LibExeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("LibExeId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("LibExe");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.Organizations", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FitAppUserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrganizationLevel")
                        .HasColumnType("int");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.ExeProgramWorkouts", b =>
                {
                    b.Property<int>("ExeProgramExeProgramId")
                        .HasColumnType("int");

                    b.Property<int>("ExeWorkoutExeWorkoutId")
                        .HasColumnType("int");

                    b.HasKey("ExeProgramExeProgramId", "ExeWorkoutExeWorkoutId");

                    b.HasIndex("ExeWorkoutExeWorkoutId");

                    b.ToTable("ExeProgramWorkouts");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.FitAppUserExePrograms", b =>
                {
                    b.Property<int>("ExeProgramExeProgramId")
                        .HasColumnType("int");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExeProgramExeProgramId", "FitAppUserId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("FitAppUserExePrograms");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationExePrograms", b =>
                {
                    b.Property<int>("OrganizationsOrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("ExeProgramExeProgramId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationsOrganizationId", "ExeProgramExeProgramId");

                    b.HasIndex("ExeProgramExeProgramId");

                    b.ToTable("OrganizationExePrograms");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationExeWorkouts", b =>
                {
                    b.Property<int>("OrganizationsOrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("ExeWorkoutExeWorkoutId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationsOrganizationId", "ExeWorkoutExeWorkoutId");

                    b.HasIndex("ExeWorkoutExeWorkoutId");

                    b.ToTable("OrganizationExeWorkouts");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationFitAppUsers", b =>
                {
                    b.Property<int>("OrganizationsOrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("FitAppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrganizationsOrganizationId", "FitAppUserId");

                    b.HasIndex("FitAppUserId");

                    b.ToTable("OrganizationFitAppUsers");
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
                            Id = "8f79a877-75a8-405b-9e24-94acb349f89e",
                            ConcurrencyStamp = "3e6c01d1-30b2-4038-8849-9ce6b46c343d",
                            Name = "Athlete",
                            NormalizedName = "ATHLETE"
                        },
                        new
                        {
                            Id = "840de69a-5818-4bfb-a6b0-1eeb1992599c",
                            ConcurrencyStamp = "66984ae4-9494-4a16-9ae9-1afae848325f",
                            Name = "Coach",
                            NormalizedName = "COACH"
                        },
                        new
                        {
                            Id = "3933e396-bc98-4176-88da-9cdc0e9f0a24",
                            ConcurrencyStamp = "5aa16087-e195-43c3-a566-68f2dd4ff5c6",
                            Name = "Level 1 Small Organization",
                            NormalizedName = "LEVEL 1 SMALL ORGANIZATION"
                        },
                        new
                        {
                            Id = "343dc2d1-c61a-4e62-a1b4-cdab49a6942e",
                            ConcurrencyStamp = "1d5cf765-79d0-4016-b8e8-1dce92fb1560",
                            Name = "Level 2 Medium Organization",
                            NormalizedName = "LEVEL 2 MEDIUM ORGANIZATION"
                        },
                        new
                        {
                            Id = "61eab27a-97f4-405a-b804-a67be1774bcc",
                            ConcurrencyStamp = "e40c47da-6f40-4803-9cd7-9eacc7ed41a8",
                            Name = "Level 3 Organization",
                            NormalizedName = "LEVEL 3 LARGE ORGANIZATION"
                        },
                        new
                        {
                            Id = "931cf437-9a91-4d4d-ba65-f6bb94dd0dad",
                            ConcurrencyStamp = "cfe9e801-9daa-49e0-a5e3-3f7ca2ad8ea5",
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

            modelBuilder.Entity("FitAppModels.BaseModels.Exe", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.ExeWorkout", "ExeWorkout")
                        .WithMany("Exe")
                        .HasForeignKey("ExeWorkoutExeWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("ExeWorkout");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeProgram", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeWorkout", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.LibExe", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.Organizations", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.ExeProgramWorkouts", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.ExeProgram", "ExeProgram")
                        .WithMany("ExeProgramWorkouts")
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.ExeWorkout", "ExeWorkout")
                        .WithMany("ExeProgramWorkouts")
                        .HasForeignKey("ExeWorkoutExeWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeProgram");

                    b.Navigation("ExeWorkout");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.FitAppUserExePrograms", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.ExeProgram", "ExeProgram")
                        .WithMany()
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany()
                        .HasForeignKey("FitAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeProgram");

                    b.Navigation("FitAppUser");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationExePrograms", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.ExeProgram", "ExeProgram")
                        .WithMany("OrganizationExePrograms")
                        .HasForeignKey("ExeProgramExeProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.Organizations", "Organizations")
                        .WithMany("OrganizationExePrograms")
                        .HasForeignKey("OrganizationsOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeProgram");

                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationExeWorkouts", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.ExeWorkout", "ExeWorkout")
                        .WithMany("OrganizationExeWorkouts")
                        .HasForeignKey("ExeWorkoutExeWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.Organizations", "Organizations")
                        .WithMany("OrganizationExeWorkouts")
                        .HasForeignKey("OrganizationsOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExeWorkout");

                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("FitAppModels.MTMModels.OrganizationFitAppUsers", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
                        .WithMany("OrganizationFitAppUsers")
                        .HasForeignKey("FitAppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.Organizations", "Organizations")
                        .WithMany("OrganizationFitAppUsers")
                        .HasForeignKey("OrganizationsOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FitAppUser");

                    b.Navigation("Organizations");
                });

            modelBuilder.Entity("FitAppModels.UserExeValues", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.Exe", "Exe")
                        .WithMany()
                        .HasForeignKey("ExeExeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitAppModels.BaseModels.FitAppUser", "FitAppUser")
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
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", null)
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

                    b.HasOne("FitAppModels.BaseModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FitAppModels.BaseModels.FitAppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeProgram", b =>
                {
                    b.Navigation("ExeProgramWorkouts");

                    b.Navigation("OrganizationExePrograms");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.ExeWorkout", b =>
                {
                    b.Navigation("Exe");

                    b.Navigation("ExeProgramWorkouts");

                    b.Navigation("OrganizationExeWorkouts");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.FitAppUser", b =>
                {
                    b.Navigation("OrganizationFitAppUsers");
                });

            modelBuilder.Entity("FitAppModels.BaseModels.Organizations", b =>
                {
                    b.Navigation("OrganizationExePrograms");

                    b.Navigation("OrganizationExeWorkouts");

                    b.Navigation("OrganizationFitAppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
