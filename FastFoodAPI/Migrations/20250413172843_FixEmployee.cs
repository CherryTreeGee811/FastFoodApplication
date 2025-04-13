using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixEmployee : Migration
    {
        /// <inheritdoc />
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
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Unassigned")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitleId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.SetNull);
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
                name: "ShiftAssignments",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignments", x => new { x.EmployeeId, x.ShiftId });
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAssignments",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    CompletedTraining = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAssignments", x => new { x.EmployeeId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_TrainingAssignments_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingAssignments_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "TrainingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Oversees restaurant operations and staff", "Manager" },
                    { 2, "Handles customer transactions and orders", "Cashier" },
                    { 3, "Prepares food according to restaurant standards", "Cook" },
                    { 4, "Maintains cleanliness of the restaurant", "Cleaner" }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "ShiftId", "ShiftPosition" },
                values: new object[,]
                {
                    { 1, "Day" },
                    { 2, "Afternoon" },
                    { 3, "Night" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Description", "IsActive", "StationName" },
                values: new object[,]
                {
                    { 1, "Administrative area for restaurant management", true, "Management Office" },
                    { 2, "Main ordering area for customers", true, "Front Counter" },
                    { 3, "Order processing for drive-thru customers", true, "Drive-Thru" },
                    { 4, "Main cooking area for burgers and grilled items", true, "Grill" },
                    { 5, "Station for fried food preparation", true, "Fryer" },
                    { 6, "Food assembly and preparation area", true, "Prep Table" },
                    { 7, "Customer seating and eating area", true, "Dining Area" }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "TrainingId", "TrainingDescription", "TrainingName" },
                values: new object[,]
                {
                    { 1, "Basic food handling and safety procedures", "Food Safety" },
                    { 2, "Effective customer interaction and problem solving", "Customer Service" },
                    { 3, "Proper cash register operations and money handling", "Cash Handling" },
                    { 4, "Standard cooking methods for menu items", "Cooking Procedures" },
                    { 5, "Restaurant cleaning protocols and standards", "Cleaning Standards" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JobTitleId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 0, "da2aaa5d-74c6-4649-be66-001b2be88e61", "james.wilson@onlybytes.com", false, "James", 3, "Wilson", false, null, "JAMES.WILSON@ONLYBYTES.COM", "JAMES.WILSON@ONLYBYTES.COM", null, null, false, "84748a36-5909-4654-b304-9ffba67ff093", 4, false, "james.wilson@onlybytes.com" },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 0, "2f5732e4-6f48-401a-9821-4380d862c32f", "sarah.johnson@onlybytes.com", false, "Sarah", 1, "Johnson", false, null, "SARAH.JOHNSON@ONLYBYTES.COM", "SARAH.JOHNSON@ONLYBYTES.COM", null, null, false, "c6e66793-e3d8-4a10-910e-80b2807b6106", 1, false, "sarah.johnson@onlybytes.com" },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 0, "34106604-6da0-41a5-b208-fcf044174cf8", "maria.hernandez@onlybytes.com", false, "Maria", 3, "Hernandez", false, null, "MARIA.HERNANDEZ@ONLYBYTES.COM", "MARIA.HERNANDEZ@ONLYBYTES.COM", null, null, false, "5805eeba-fc1c-4a79-b979-870ca509be2c", 5, false, "maria.hernandez@onlybytes.com" },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 0, "8aafc2e0-df58-4710-b5d4-2eb29b7d3b55", "lisa.anderson@onlybytes.com", false, "Lisa", 4, "Anderson", false, null, "LISA.ANDERSON@ONLYBYTES.COM", "LISA.ANDERSON@ONLYBYTES.COM", null, null, false, "2adbb622-c951-4734-ae73-4eec4cb1f479", 7, false, "lisa.anderson@onlybytes.com" },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 0, "fb71e81f-2b0b-4f68-ac3f-a33ed965eec4", "john.doe@onlybytes.com", false, "John", 1, "Doe", false, null, "JOHN.DOE@ONLYBYTES.COM", "JOHN.DOE@ONLYBYTES.COM", null, null, false, "215d07dc-e3b8-411f-bd44-27567c4a4cec", 1, false, "john.doe@onlybytes.com" },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 0, "5c3f074c-ed85-4d03-afc5-de39d69427aa", "carlos.gomez@onlybytes.com", false, "Carlos", 4, "Gomez", false, null, "CARLOS.GOMEZ@ONLYBYTES.COM", "CARLOS.GOMEZ@ONLYBYTES.COM", null, null, false, "9d294c99-76ad-4f4c-8598-019e3e35cd43", 7, false, "carlos.gomez@onlybytes.com" },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 0, "3cc29c83-a3d8-4e77-bade-577a58cdefeb", "kevin.kim@onlybytes.com", false, "Kevin", 3, "Kim", false, null, "KEVIN.KIM@ONLYBYTES.COM", "KEVIN.KIM@ONLYBYTES.COM", null, null, false, "b8937ed6-aa20-48f3-b1aa-2358b906c3ea", 6, false, "kevin.kim@onlybytes.com" },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 0, "ba48a4ee-680e-4350-914a-3fd955bc4206", "mike.wilson@onlybytes.com", false, "Mike", 3, "Wilson", false, null, "MIKE.WILSON@ONLYBYTES.COM", "MIKE.WILSON@ONLYBYTES.COM", null, null, false, "c44475e6-c58e-4b8c-ba5a-2b8ad5303ea9", 4, false, "mike.wilson@onlybytes.com" },
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 0, "1e46073b-c928-4f2c-8d65-d7880bc8bf24", "thomas.lee@onlybytes.com", false, "Thomas", 2, "Lee", false, null, "THOMAS.LEE@ONLYBYTES.COM", "THOMAS.LEE@ONLYBYTES.COM", null, null, false, "29931e57-3cfe-4304-8e90-1e4c00c85282", 3, false, "thomas.lee@onlybytes.com" },
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 0, "18c85f65-8d84-4b5b-8bcd-17e55974de83", "sophia.patel@onlybytes.com", false, "Sophia", 2, "Patel", false, null, "SOPHIA.PATEL@ONLYBYTES.COM", "SOPHIA.PATEL@ONLYBYTES.COM", null, null, false, "27bc350f-8ebd-4307-a9af-81133974f89b", 2, false, "sophia.patel@onlybytes.com" },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 0, "9a209f4d-947a-4b7b-9fbc-d1f0ead6c14a", "emma.wright@onlybytes.com", false, "Emma", 4, "Wright", false, null, "EMMA.WRIGHT@ONLYBYTES.COM", "EMMA.WRIGHT@ONLYBYTES.COM", null, null, false, "89e1ea2c-a5d8-4b52-8c88-1755872d5110", 7, false, "emma.wright@onlybytes.com" },
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 0, "379cc76e-d222-4613-9a0e-1900420fd0ad", "olivia.rodriguez@onlybytes.com", false, "Olivia", 2, "Rodriguez", false, null, "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", null, null, false, "531c0ca6-b393-4875-9014-2588dfd0e520", 2, false, "olivia.rodriguez@onlybytes.com" },
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 0, "32b1db7e-4ea9-4f9b-88a8-114504b1c055", "daniel.thompson@onlybytes.com", false, "Daniel", 2, "Thompson", false, null, "DANIEL.THOMPSON@ONLYBYTES.COM", "DANIEL.THOMPSON@ONLYBYTES.COM", null, null, false, "fe5f7a34-568b-43d3-a693-752f10566a0b", 3, false, "daniel.thompson@onlybytes.com" },
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 0, "562ce9ba-5f51-45b2-a523-55f2cf1cc514", "michael.brown@onlybytes.com", false, "Michael", 2, "Brown", false, null, "MICHAEL.BROWN@ONLYBYTES.COM", "MICHAEL.BROWN@ONLYBYTES.COM", null, null, false, "e855fc78-c49a-4a40-9f7f-fc9454daa37c", 3, false, "michael.brown@onlybytes.com" },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 0, "84dca25b-65c4-4101-b06a-b0dc893947e0", "robert.taylor@onlybytes.com", false, "Robert", 4, "Taylor", false, null, "ROBERT.TAYLOR@ONLYBYTES.COM", "ROBERT.TAYLOR@ONLYBYTES.COM", null, null, false, "e2f11d82-7230-4a48-91d5-02ea9d4198a8", 7, false, "robert.taylor@onlybytes.com" },
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 0, "e09a7b63-85f3-4808-a961-985bd9e0f632", "jane.smith@onlybytes.com", false, "Jane", 2, "Smith", false, null, "JANE.SMITH@ONLYBYTES.COM", "JANE.SMITH@ONLYBYTES.COM", null, null, false, "255e30c3-8d50-4fc6-97d7-e7c5c894b270", 2, false, "jane.smith@onlybytes.com" },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 0, "d12d25c2-24ff-470b-ad29-ca40cb583b48", "jessica.martinez@onlybytes.com", false, "Jessica", 3, "Martinez", false, null, "JESSICA.MARTINEZ@ONLYBYTES.COM", "JESSICA.MARTINEZ@ONLYBYTES.COM", null, null, false, "df0061e8-aadf-4f28-83de-b9b98aef1387", 6, false, "jessica.martinez@onlybytes.com" },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 0, "da2ac9ab-b0e3-46f5-bfd0-ad350bede139", "jennifer.chen@onlybytes.com", false, "Jennifer", 3, "Chen", false, null, "JENNIFER.CHEN@ONLYBYTES.COM", "JENNIFER.CHEN@ONLYBYTES.COM", null, null, false, "c6c54f10-f90c-4993-98e8-2dab56eb0c80", 4, false, "jennifer.chen@onlybytes.com" },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 0, "75cc3512-33ad-45e0-936f-51bbddd71af1", "amanda.williams@onlybytes.com", false, "Amanda", 1, "Williams", false, null, "AMANDA.WILLIAMS@ONLYBYTES.COM", "AMANDA.WILLIAMS@ONLYBYTES.COM", null, null, false, "8099b455-8830-4685-941c-aad93c47401f", 1, false, "amanda.williams@onlybytes.com" },
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 0, "b6beaf2b-8f2d-4a01-bccb-1df51d71cfb7", "emily.davis@onlybytes.com", false, "Emily", 2, "Davis", false, null, "EMILY.DAVIS@ONLYBYTES.COM", "EMILY.DAVIS@ONLYBYTES.COM", null, null, false, "362e5e8f-fc1e-4b6b-b789-ea286fcc0a6f", 2, false, "emily.davis@onlybytes.com" },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 0, "562101c4-6a05-470b-8913-5a30fad981cf", "david.garcia@onlybytes.com", false, "David", 3, "Garcia", false, null, "DAVID.GARCIA@ONLYBYTES.COM", "DAVID.GARCIA@ONLYBYTES.COM", null, null, false, "053b5ce0-fb39-4c8d-967c-ff1b9e949eca", 5, false, "david.garcia@onlybytes.com" },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 0, "fa18a3e5-fe4a-41b2-875f-df7365584e5f", "richard.parker@onlybytes.com", false, "Richard", 1, "Parker", false, null, "RICHARD.PARKER@ONLYBYTES.COM", "RICHARD.PARKER@ONLYBYTES.COM", null, null, false, "dc3e2758-6fa1-4768-a369-9bd0ab7875f1", 1, false, "richard.parker@onlybytes.com" }
                });

            migrationBuilder.InsertData(
                table: "ShiftAssignments",
                columns: new[] { "EmployeeId", "ShiftId", "ShiftDate" },
                values: new object[,]
                {
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 1, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 2, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 2, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 2, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 3, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 1, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 3, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 3, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 3, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 2, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 2, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 1, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 3, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 3, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 1, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 3, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 2, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 1, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 3, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9951) },
                    { "05d17d04-3c61-4d1c-8e52-f6cc7c3bf9bf", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9953) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9883) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9886) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9888) },
                    { "07c4d294-fd34-4882-83c1-4e2ac1be48f7", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9891) },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9955) },
                    { "11cc7b1a-09ba-48b6-a062-1b84769ed181", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9956) },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9971) },
                    { "161eb0ca-8546-49af-aa84-7891c6e75f05", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9972) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(8988) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "3052ecc5-6773-49e4-94f6-8303318375fe", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9860) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9871) },
                    { "3052ecc5-6773-49e4-94f6-8303318375fe", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9874) },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9974) },
                    { "396509bb-6fcc-43f2-8a6c-59b107b148de", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9988) },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9958) },
                    { "3a4088e6-f9f2-459a-91f3-d86d52d6ba16", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9960) },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9940) },
                    { "41893200-b954-40f2-9ab8-fd11ecf243b0", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9943) },
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9932) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "6139a95f-6ef3-4160-9cc2-45914eb759a6", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9934) },
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9937) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "6cd3cd47-9274-4f6d-ac00-54e6dab140f5", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9939) },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9990) },
                    { "858ee96a-ffb3-4647-afe6-7dcf15bac408", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9991) },
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9927) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "87dd16c6-7fe5-43e2-a378-8de5b3c8aff9", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9930) },
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9923) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "8efb3ddf-77b9-4f66-a6c5-08e3d0e1a4fb", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9925) },
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9915) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "ac8baf0a-aeb8-40c5-a8b4-632c5f692b70", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9917) },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9965) },
                    { "aed9019e-f2c4-4797-bcef-38c10124c27b", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9967) },
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9910) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "b27ce3ff-1b76-4c28-9368-74cee1b1c104", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9912) },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9948) },
                    { "c34a7241-df42-4185-bee7-f5d1e329218c", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9950) },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9962) },
                    { "d8838fca-fee1-4a1c-b320-95262db7cd9a", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9963) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9901) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9904) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9906) },
                    { "d8be7bf6-f6ad-4835-8408-0ee470aef7a8", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9907) },
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9919) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "de06c55e-1814-486a-805e-72a0d925cc13", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "de06c55e-1814-486a-805e-72a0d925cc13", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9921) },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9945) },
                    { "fc124823-5743-41fd-aded-24a88ef1e44c", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9946) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 1, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9893) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 2, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 3, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9895) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 4, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9896) },
                    { "ffc8c095-b46d-43d1-9976-9ea42f4a171d", 5, true, new DateTime(2025, 3, 13, 13, 28, 42, 359, DateTimeKind.Local).AddTicks(9898) }
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
                name: "IX_AspNetUsers_JobTitleId",
                table: "AspNetUsers",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StationId",
                table: "AspNetUsers",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAssignments_ShiftId",
                table: "ShiftAssignments",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAssignments_TrainingId",
                table: "TrainingAssignments",
                column: "TrainingId");
        }

        /// <inheritdoc />
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
                name: "ShiftAssignments");

            migrationBuilder.DropTable(
                name: "TrainingAssignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
