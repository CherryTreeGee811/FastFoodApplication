using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class ShiftAssignmentsFix : Migration
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
                    table.PrimaryKey("PK_ShiftAssignments", x => new { x.EmployeeId, x.ShiftId, x.ShiftDate });
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
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", 0, "63a37300-8703-4419-be2a-b6174ad9df65", "thomas.lee@onlybytes.com", false, "Thomas", 2, "Lee", false, null, "THOMAS.LEE@ONLYBYTES.COM", "THOMAS.LEE@ONLYBYTES.COM", null, null, false, "5dfdb09f-4546-4b77-b3b1-4d220764fad8", 3, false, "thomas.lee@onlybytes.com" },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", 0, "d2b095bf-06a9-4d0e-a834-041abbb7f1d4", "james.wilson@onlybytes.com", false, "James", 3, "Wilson", false, null, "JAMES.WILSON@ONLYBYTES.COM", "JAMES.WILSON@ONLYBYTES.COM", null, null, false, "b856cad0-e559-401c-a0a3-fcfcd80358ca", 4, false, "james.wilson@onlybytes.com" },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", 0, "ffde4a25-31fe-4d3f-8ee9-906c680b0e9d", "amanda.williams@onlybytes.com", false, "Amanda", 1, "Williams", false, null, "AMANDA.WILLIAMS@ONLYBYTES.COM", "AMANDA.WILLIAMS@ONLYBYTES.COM", null, null, false, "d4a136f9-0934-4ee5-8f36-3a08a3587e3e", 1, false, "amanda.williams@onlybytes.com" },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", 0, "80349df5-e288-4aef-87c3-49102ab9b5ec", "kevin.kim@onlybytes.com", false, "Kevin", 3, "Kim", false, null, "KEVIN.KIM@ONLYBYTES.COM", "KEVIN.KIM@ONLYBYTES.COM", null, null, false, "7e60645f-ef60-42b2-bf32-988f3550aa92", 6, false, "kevin.kim@onlybytes.com" },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", 0, "3018e553-d9c5-4831-bf4e-d14b77966b38", "emily.davis@onlybytes.com", false, "Emily", 2, "Davis", false, null, "EMILY.DAVIS@ONLYBYTES.COM", "EMILY.DAVIS@ONLYBYTES.COM", null, null, false, "42a2a195-4713-4af4-bd2f-adf43e44281a", 2, false, "emily.davis@onlybytes.com" },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 0, "4bc6b79d-f0b1-458b-a0ab-634647fec3f7", "john.doe@onlybytes.com", false, "John", 1, "Doe", false, null, "JOHN.DOE@ONLYBYTES.COM", "JOHN.DOE@ONLYBYTES.COM", null, null, false, "d23be876-c0a7-4077-b0f1-4c5a7e67687b", 1, false, "john.doe@onlybytes.com" },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", 0, "8222057d-0fa8-4b27-a175-7b82a5446613", "robert.taylor@onlybytes.com", false, "Robert", 4, "Taylor", false, null, "ROBERT.TAYLOR@ONLYBYTES.COM", "ROBERT.TAYLOR@ONLYBYTES.COM", null, null, false, "5d8fedcd-c4af-414e-b301-eb7f271490e6", 7, false, "robert.taylor@onlybytes.com" },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 0, "07e9e499-4ef1-4fcf-9b6b-091d0cce8439", "richard.parker@onlybytes.com", false, "Richard", 1, "Parker", false, null, "RICHARD.PARKER@ONLYBYTES.COM", "RICHARD.PARKER@ONLYBYTES.COM", null, null, false, "2ff156c5-b282-4541-9c2c-820b4933a038", 1, false, "richard.parker@onlybytes.com" },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", 0, "b8dd2043-ad23-4c96-a581-adf59daaab19", "daniel.thompson@onlybytes.com", false, "Daniel", 2, "Thompson", false, null, "DANIEL.THOMPSON@ONLYBYTES.COM", "DANIEL.THOMPSON@ONLYBYTES.COM", null, null, false, "7ac9422c-772e-45f4-9851-95834edd3bab", 3, false, "daniel.thompson@onlybytes.com" },
                    { "528d949c-a620-4665-b994-6a4e48664c52", 0, "c74c0d19-d9c5-4110-ab91-86ca415edefd", "jane.smith@onlybytes.com", false, "Jane", 2, "Smith", false, null, "JANE.SMITH@ONLYBYTES.COM", "JANE.SMITH@ONLYBYTES.COM", null, null, false, "a092f8a1-9d0d-41df-854e-b072198c09f4", 2, false, "jane.smith@onlybytes.com" },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", 0, "45504975-e2e4-4029-81e1-7bb53bf2cb7a", "david.garcia@onlybytes.com", false, "David", 3, "Garcia", false, null, "DAVID.GARCIA@ONLYBYTES.COM", "DAVID.GARCIA@ONLYBYTES.COM", null, null, false, "d116f76f-d1b6-4e41-9000-b787a56ba543", 5, false, "david.garcia@onlybytes.com" },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", 0, "92b969a1-63e4-4688-8319-b570ec0a8c49", "carlos.gomez@onlybytes.com", false, "Carlos", 4, "Gomez", false, null, "CARLOS.GOMEZ@ONLYBYTES.COM", "CARLOS.GOMEZ@ONLYBYTES.COM", null, null, false, "eeccc281-68a2-4abf-9a9c-4d172ca0e5a3", 7, false, "carlos.gomez@onlybytes.com" },
                    { "72712137-3803-4054-83ff-48ef02e7613a", 0, "e6ac011c-08f9-476d-8e40-a88278c0086f", "lisa.anderson@onlybytes.com", false, "Lisa", 4, "Anderson", false, null, "LISA.ANDERSON@ONLYBYTES.COM", "LISA.ANDERSON@ONLYBYTES.COM", null, null, false, "9a9fa03d-0868-4191-ab11-82dbb450e4e8", 7, false, "lisa.anderson@onlybytes.com" },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 0, "e2c30d6a-7c93-4a7c-975a-3d4f6f0a6d3f", "sarah.johnson@onlybytes.com", false, "Sarah", 1, "Johnson", false, null, "SARAH.JOHNSON@ONLYBYTES.COM", "SARAH.JOHNSON@ONLYBYTES.COM", null, null, false, "f2db16da-a51c-4b5b-9049-478614fb7005", 1, false, "sarah.johnson@onlybytes.com" },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", 0, "d5a16252-3d00-48ef-baae-fbe34f80ebb6", "emma.wright@onlybytes.com", false, "Emma", 4, "Wright", false, null, "EMMA.WRIGHT@ONLYBYTES.COM", "EMMA.WRIGHT@ONLYBYTES.COM", null, null, false, "64c36db7-9b55-44d8-951a-976b83bc9f24", 7, false, "emma.wright@onlybytes.com" },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", 0, "85dd3a27-8751-4043-a148-fc3d80b5f9c5", "michael.brown@onlybytes.com", false, "Michael", 2, "Brown", false, null, "MICHAEL.BROWN@ONLYBYTES.COM", "MICHAEL.BROWN@ONLYBYTES.COM", null, null, false, "a27f7b97-5f6a-402d-b195-caf3724cdc7a", 3, false, "michael.brown@onlybytes.com" },
                    { "af365533-bfd8-45d5-8585-922447810848", 0, "5fbbf840-0963-4de2-a012-3fd6c5daf7c3", "jennifer.chen@onlybytes.com", false, "Jennifer", 3, "Chen", false, null, "JENNIFER.CHEN@ONLYBYTES.COM", "JENNIFER.CHEN@ONLYBYTES.COM", null, null, false, "f5945159-4c11-4c30-ba10-d749380e6b70", 4, false, "jennifer.chen@onlybytes.com" },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", 0, "9007ec6b-fd20-4053-8534-6b6137f68d1a", "jessica.martinez@onlybytes.com", false, "Jessica", 3, "Martinez", false, null, "JESSICA.MARTINEZ@ONLYBYTES.COM", "JESSICA.MARTINEZ@ONLYBYTES.COM", null, null, false, "bbad628f-f98b-4a3d-8633-26fa7634fb7a", 6, false, "jessica.martinez@onlybytes.com" },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", 0, "16e18a88-0ffe-4367-88c4-310d00265298", "mike.wilson@onlybytes.com", false, "Mike", 3, "Wilson", false, null, "MIKE.WILSON@ONLYBYTES.COM", "MIKE.WILSON@ONLYBYTES.COM", null, null, false, "7a9e70a4-5730-41e5-9fd3-85e6fbf94bbf", 4, false, "mike.wilson@onlybytes.com" },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", 0, "485d94e2-f578-4d08-8036-7091d19d2a4d", "maria.hernandez@onlybytes.com", false, "Maria", 3, "Hernandez", false, null, "MARIA.HERNANDEZ@ONLYBYTES.COM", "MARIA.HERNANDEZ@ONLYBYTES.COM", null, null, false, "62eb0639-c1c4-4cf5-a3f2-0d9fdc5833a2", 5, false, "maria.hernandez@onlybytes.com" },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", 0, "7bb9714f-7d68-4d6a-b727-9961d4eb69c9", "sophia.patel@onlybytes.com", false, "Sophia", 2, "Patel", false, null, "SOPHIA.PATEL@ONLYBYTES.COM", "SOPHIA.PATEL@ONLYBYTES.COM", null, null, false, "2b028c91-5d3e-465b-a45e-ca38b0a1abb3", 2, false, "sophia.patel@onlybytes.com" },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", 0, "ab6b98c0-c6d6-4fef-a672-6e39de2a0316", "olivia.rodriguez@onlybytes.com", false, "Olivia", 2, "Rodriguez", false, null, "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", null, null, false, "670dc041-cca4-4f04-a04f-e2cef95a93dd", 2, false, "olivia.rodriguez@onlybytes.com" }
                });

            migrationBuilder.InsertData(
                table: "ShiftAssignments",
                columns: new[] { "EmployeeId", "ShiftDate", "ShiftId" },
                values: new object[,]
                {
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "528d949c-a620-4665-b994-6a4e48664c52", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "72712137-3803-4054-83ff-48ef02e7613a", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "af365533-bfd8-45d5-8585-922447810848", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "028fc5db-f747-4e6e-b55e-0fe0f9d96bc2", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "02ec15d1-9770-4928-aff1-dee34ea7182e", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "05f5e67c-8be2-42ed-8921-37d041edce53", 3, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", 4, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "05f5e67c-8be2-42ed-8921-37d041edce53", 5, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "1e41bce4-f1ac-4959-9890-703bd96b6100", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "2e3348f8-bfa7-4cb3-886d-b4eda758296a", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 4, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "379ed7fb-5175-4ae9-94cb-48d3c8177575", 5, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "3da38824-68e2-42ed-93c6-279c9e3dbd36", 5, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 4, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "428e0fbe-5ce1-41f9-93fe-dc8ee7c8f066", 5, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "4b0b7e01-c3b8-4162-b78d-af843b9dc0ea", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "528d949c-a620-4665-b994-6a4e48664c52", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[,]
                {
                    { "528d949c-a620-4665-b994-6a4e48664c52", 2, null },
                    { "528d949c-a620-4665-b994-6a4e48664c52", 3, null }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "6f476443-fcd2-47b0-99db-553f52992e46", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "6f476443-fcd2-47b0-99db-553f52992e46", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "7000f3a5-7bbd-4188-9d22-2927b5b92690", 5, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "72712137-3803-4054-83ff-48ef02e7613a", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "72712137-3803-4054-83ff-48ef02e7613a", 5, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 4, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "780d7f8a-62e8-41f6-b073-9b6248d48457", 5, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { "8279e5c9-92f0-48d3-b518-c2b08d1692fb", 5, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "994472f4-ef58-4119-b24b-7e8c0892ebeb", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "af365533-bfd8-45d5-8585-922447810848", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "af365533-bfd8-45d5-8585-922447810848", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "b09f202e-cf89-4ba0-a30e-a8a7a85f8b7b", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "c4ca4f14-b573-4150-8aca-dd523394fcfa", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "ccde56fe-6883-446a-a51e-4c6dffb929ca", 4, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", 1, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", 2, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "e92e803f-0cc2-497d-865b-eff6477cc243", 3, true, new DateTime(2025, 3, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", 1, true, new DateTime(2025, 1, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", 2, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) },
                    { "fd442d98-fe45-44d3-8c45-aa113aef0c96", 3, true, new DateTime(2025, 2, 13, 20, 47, 25, 225, DateTimeKind.Local).AddTicks(7951) }
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
