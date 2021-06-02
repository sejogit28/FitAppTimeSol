using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitAppDataStoreEF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibExe",
                columns: table => new
                {
                    LibExeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibExeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibExe", x => x.LibExeId);
                    table.ForeignKey(
                        name: "FK_LibExe_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ExeProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ExeProgramId);
                    table.ForeignKey(
                        name: "FK_Program_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    WorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GoalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.WorkoutId);
                    table.ForeignKey(
                        name: "FK_Workout_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FitAppUserExePrograms",
                columns: table => new
                {
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExeProgramExeProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitAppUserExePrograms", x => new { x.ExeProgramExeProgramId, x.FitAppUserId });
                    table.ForeignKey(
                        name: "FK_FitAppUserExePrograms_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitAppUserExePrograms_Program_ExeProgramExeProgramId",
                        column: x => x.ExeProgramExeProgramId,
                        principalTable: "Program",
                        principalColumn: "ExeProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exe",
                columns: table => new
                {
                    ExeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    EachSide = table.Column<bool>(type: "bit", nullable: false),
                    WorkoutGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutGroupOrder = table.Column<int>(type: "int", nullable: false),
                    Tempo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExeNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FitAppUserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutWorkoutId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exe", x => x.ExeId);
                    table.ForeignKey(
                        name: "FK_Exe_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exe_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExeProgramWorkouts",
                columns: table => new
                {
                    ExeProgramExeProgramId = table.Column<int>(type: "int", nullable: false),
                    WorkoutWorkoutId = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExeProgramWorkouts", x => new { x.ExeProgramExeProgramId, x.WorkoutWorkoutId });
                    table.ForeignKey(
                        name: "FK_ExeProgramWorkouts_Program_ExeProgramExeProgramId",
                        column: x => x.ExeProgramExeProgramId,
                        principalTable: "Program",
                        principalColumn: "ExeProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExeProgramWorkouts_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "WorkoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserExeValues",
                columns: table => new
                {
                    FitAppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExeExeId = table.Column<int>(type: "int", nullable: false),
                    EnteredValuesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Set1Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set2Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set3Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set4Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set5Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set6Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set7Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set8Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set9Values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Set10Values = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExeValues", x => new { x.FitAppUserId, x.ExeExeId, x.EnteredValuesDate });
                    table.ForeignKey(
                        name: "FK_UserExeValues_AspNetUsers_FitAppUserId",
                        column: x => x.FitAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExeValues_Exe_ExeExeId",
                        column: x => x.ExeExeId,
                        principalTable: "Exe",
                        principalColumn: "ExeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e6ed6b79-72ab-4dfe-8930-23b1b8e083b8", "00422203-096f-49ad-a869-8868df9047a1", "Athlete", "ATHLETE" },
                    { "59008d9a-35c4-47bd-9d33-3e3a9c04b82d", "80f91ed6-7c1b-4450-89ce-dbee5524655c", "Coach", "COACH" },
                    { "33267863-5757-4436-ad8c-6a400f1c399a", "8a0e1c25-30eb-4f23-8d18-e089a710a977", "Head Coach", "HEAD COACH" },
                    { "c5a8a465-3495-4a86-b827-a1de0c218149", "e596863c-63fc-46a7-98c2-6f3149d2fe70", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exe_FitAppUserId",
                table: "Exe",
                column: "FitAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exe_WorkoutId",
                table: "Exe",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExeProgramWorkouts_WorkoutId",
                table: "ExeProgramWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_FitAppUserExePrograms_FitAppUserId",
                table: "FitAppUserExePrograms",
                column: "FitAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LibExe_FitAppUserId",
                table: "LibExe",
                column: "FitAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_FitAppUserId",
                table: "Program",
                column: "FitAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExeValues_ExeExeId",
                table: "UserExeValues",
                column: "ExeExeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workout_FitAppUserId",
                table: "Workout",
                column: "FitAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExeProgramWorkouts");

            migrationBuilder.DropTable(
                name: "FitAppUserExePrograms");

            migrationBuilder.DropTable(
                name: "LibExe");

            migrationBuilder.DropTable(
                name: "UserExeValues");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Exe");

            migrationBuilder.DropTable(
                name: "Workout");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
