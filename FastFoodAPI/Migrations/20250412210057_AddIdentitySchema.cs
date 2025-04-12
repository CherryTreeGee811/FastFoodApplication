using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentitySchema : Migration
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.UniqueConstraint("AK_AspNetUsers_EmployeeId", x => x.EmployeeId);
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAssignments", x => new { x.EmployeeId, x.ShiftId, x.ShiftDate });
                    table.ForeignKey(
                        name: "FK_ShiftAssignments_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "EmployeeId",
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "EmployeeId",
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailAddress", "EmailConfirmed", "EmployeeId", "FirstName", "JobTitleId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StationId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "054966be-da7c-4b6e-a9a7-a6676e1eae10", 0, "630ad2ed-10fc-443c-90eb-3addb2e028bb", "maria.hernandez@onlybytes.com", "maria.hernandez@onlybytes.com", false, 18, "Maria", 3, "Hernandez", false, null, "MARIA.HERNANDEZ@ONLYBYTES.COM", "MARIA.HERNANDEZ@ONLYBYTES.COM", null, null, false, "d56635e4-103c-4f63-a605-1cd1d8a934ee", 5, false, "maria.hernandez@onlybytes.com" },
                    { "06565424-7337-46e2-ae34-02bbb74ecc05", 0, "d2724146-0b9b-4cb8-ade3-f05bb92914a3", "jennifer.chen@onlybytes.com", "jennifer.chen@onlybytes.com", false, 20, "Jennifer", 3, "Chen", false, null, "JENNIFER.CHEN@ONLYBYTES.COM", "JENNIFER.CHEN@ONLYBYTES.COM", null, null, false, "d0d4bcbe-431d-4e1f-9673-e7fed20efa75", 4, false, "jennifer.chen@onlybytes.com" },
                    { "1633f9cf-b75b-43cd-8a45-be81bd60957f", 0, "d8a7f67e-5b35-45c3-8c65-78916d2109ae", "mike.wilson@onlybytes.com", "mike.wilson@onlybytes.com", false, 6, "Mike", 3, "Wilson", false, null, "MIKE.WILSON@ONLYBYTES.COM", "MIKE.WILSON@ONLYBYTES.COM", null, null, false, "7893671a-d5b2-4c75-8a69-1683cb357571", 4, false, "mike.wilson@onlybytes.com" },
                    { "1dfbdb80-44a2-4b69-bd10-dcff2f80764a", 0, "a30aec09-2a4f-4b93-81ea-1d79a250379d", "sarah.johnson@onlybytes.com", "sarah.johnson@onlybytes.com", false, 2, "Sarah", 1, "Johnson", false, null, "SARAH.JOHNSON@ONLYBYTES.COM", "SARAH.JOHNSON@ONLYBYTES.COM", null, null, false, "89cc13d5-be43-4960-b59e-5cf37b9dd2ce", 1, false, "sarah.johnson@onlybytes.com" },
                    { "2598c336-9217-4014-8a1d-3df2fdb2a7d0", 0, "b334c22c-eee0-49b4-9e2d-afa4549775d4", "carlos.gomez@onlybytes.com", "carlos.gomez@onlybytes.com", false, 21, "Carlos", 4, "Gomez", false, null, "CARLOS.GOMEZ@ONLYBYTES.COM", "CARLOS.GOMEZ@ONLYBYTES.COM", null, null, false, "69eac15f-61c0-4717-87e4-0c372688d28e", 7, false, "carlos.gomez@onlybytes.com" },
                    { "26a29b25-037e-445a-9fe2-67bded3b72a4", 0, "3698c477-a8a8-4679-8361-2d8cd0fd5868", "michael.brown@onlybytes.com", "michael.brown@onlybytes.com", false, 4, "Michael", 2, "Brown", false, null, "MICHAEL.BROWN@ONLYBYTES.COM", "MICHAEL.BROWN@ONLYBYTES.COM", null, null, false, "4a14c23d-c9c5-4412-b8bf-c2eda37a18b9", 3, false, "michael.brown@onlybytes.com" },
                    { "27eed73a-1bd8-495e-970d-525459ec73f8", 0, "1dd5e337-ffb1-4c33-82f3-2022133fd803", "john.doe@onlybytes.com", "john.doe@onlybytes.com", false, 1, "John", 1, "Doe", false, null, "JOHN.DOE@ONLYBYTES.COM", "JOHN.DOE@ONLYBYTES.COM", null, null, false, "892afd4a-7861-4b0c-83a4-6200dd5af3f4", 1, false, "john.doe@onlybytes.com" },
                    { "34b910ef-276e-42d6-a3fb-8841e761133c", 0, "e0da6738-d2c8-4b77-9c67-5862e9f85973", "olivia.rodriguez@onlybytes.com", "olivia.rodriguez@onlybytes.com", false, 14, "Olivia", 2, "Rodriguez", false, null, "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", null, null, false, "c47b7434-60da-4bcc-86e7-907d7e08e78f", 2, false, "olivia.rodriguez@onlybytes.com" },
                    { "40391d05-196e-42ca-80c3-621d809c3a99", 0, "040458b8-5ba5-412a-9f1a-4867e1680a42", "richard.parker@onlybytes.com", "richard.parker@onlybytes.com", false, 11, "Richard", 1, "Parker", false, null, "RICHARD.PARKER@ONLYBYTES.COM", "RICHARD.PARKER@ONLYBYTES.COM", null, null, false, "5bb84938-3290-4192-9e0f-983aa36c30b7", 1, false, "richard.parker@onlybytes.com" },
                    { "4dc38e9f-8776-4ff5-b62d-3edd1858738e", 0, "f93f28d6-aa85-4e09-bdbd-b80d329c0b58", "david.garcia@onlybytes.com", "david.garcia@onlybytes.com", false, 7, "David", 3, "Garcia", false, null, "DAVID.GARCIA@ONLYBYTES.COM", "DAVID.GARCIA@ONLYBYTES.COM", null, null, false, "4307b406-175f-4656-ad76-d9e231442bb8", 5, false, "david.garcia@onlybytes.com" },
                    { "5e34f77b-f7df-42c7-8901-261b5c95950b", 0, "e779b1e7-074b-4883-8c09-252979ce6130", "lisa.anderson@onlybytes.com", "lisa.anderson@onlybytes.com", false, 10, "Lisa", 4, "Anderson", false, null, "LISA.ANDERSON@ONLYBYTES.COM", "LISA.ANDERSON@ONLYBYTES.COM", null, null, false, "e47dfb0a-c528-4d0b-a83c-bdd775b1c603", 7, false, "lisa.anderson@onlybytes.com" },
                    { "62b6e34e-f377-4aef-941d-9ff36f67d845", 0, "630578cd-9264-4567-acf1-2ed3e891d152", "james.wilson@onlybytes.com", "james.wilson@onlybytes.com", false, 17, "James", 3, "Wilson", false, null, "JAMES.WILSON@ONLYBYTES.COM", "JAMES.WILSON@ONLYBYTES.COM", null, null, false, "30aa9a18-52f0-47a2-a623-6cb2f7fe56cc", 4, false, "james.wilson@onlybytes.com" },
                    { "67f3d131-b306-49b7-86fc-4b1745934aac", 0, "f6abadce-8241-4f14-ac4a-88625fb98822", "emma.wright@onlybytes.com", "emma.wright@onlybytes.com", false, 22, "Emma", 4, "Wright", false, null, "EMMA.WRIGHT@ONLYBYTES.COM", "EMMA.WRIGHT@ONLYBYTES.COM", null, null, false, "22209a96-0f27-4283-993e-630ee0c60e43", 7, false, "emma.wright@onlybytes.com" },
                    { "7d0b611d-d339-433a-b630-6eb5213498bb", 0, "9ad6d98c-2a1c-48d2-b759-1b4635a42466", "amanda.williams@onlybytes.com", "amanda.williams@onlybytes.com", false, 12, "Amanda", 1, "Williams", false, null, "AMANDA.WILLIAMS@ONLYBYTES.COM", "AMANDA.WILLIAMS@ONLYBYTES.COM", null, null, false, "7157752d-1133-4209-8685-a9a87b4acd65", 1, false, "amanda.williams@onlybytes.com" },
                    { "8a8c0dd0-dbbd-4913-a10b-33d680d96e3b", 0, "cb8f507d-9eda-4301-bffc-f935d99ab09d", "kevin.kim@onlybytes.com", "kevin.kim@onlybytes.com", false, 19, "Kevin", 3, "Kim", false, null, "KEVIN.KIM@ONLYBYTES.COM", "KEVIN.KIM@ONLYBYTES.COM", null, null, false, "94af3bf6-51ec-4744-ac53-ac0de99f6dd0", 6, false, "kevin.kim@onlybytes.com" },
                    { "a1a60395-7977-4c48-9505-995dd6c722fc", 0, "47b5c5a9-9372-47ce-99b3-98a5f401392e", "sophia.patel@onlybytes.com", "sophia.patel@onlybytes.com", false, 16, "Sophia", 2, "Patel", false, null, "SOPHIA.PATEL@ONLYBYTES.COM", "SOPHIA.PATEL@ONLYBYTES.COM", null, null, false, "cce3a867-717e-40aa-9da4-b01f64af265e", 2, false, "sophia.patel@onlybytes.com" },
                    { "aa1849e0-71cb-4ee3-9618-9194581714b2", 0, "eb28c8f7-8064-49d0-ad15-5827b341d482", "robert.taylor@onlybytes.com", "robert.taylor@onlybytes.com", false, 9, "Robert", 4, "Taylor", false, null, "ROBERT.TAYLOR@ONLYBYTES.COM", "ROBERT.TAYLOR@ONLYBYTES.COM", null, null, false, "a30ac11e-8e17-48aa-9e46-8c71798d77df", 7, false, "robert.taylor@onlybytes.com" },
                    { "b15c2746-3b78-46a4-84e8-67df11c9af17", 0, "bd016b33-c0c6-43a5-adec-af7a9cbb69a0", "jessica.martinez@onlybytes.com", "jessica.martinez@onlybytes.com", false, 8, "Jessica", 3, "Martinez", false, null, "JESSICA.MARTINEZ@ONLYBYTES.COM", "JESSICA.MARTINEZ@ONLYBYTES.COM", null, null, false, "252887b5-e2f0-4f7a-89aa-47a71dc17770", 6, false, "jessica.martinez@onlybytes.com" },
                    { "b862c298-0bb1-4fa6-88d3-68f41e7e5ce5", 0, "0ae43b11-adbd-4a32-9e92-edf0f6d4ed38", "thomas.lee@onlybytes.com", "thomas.lee@onlybytes.com", false, 15, "Thomas", 2, "Lee", false, null, "THOMAS.LEE@ONLYBYTES.COM", "THOMAS.LEE@ONLYBYTES.COM", null, null, false, "21761950-feeb-4589-943d-8de7fda08cb0", 3, false, "thomas.lee@onlybytes.com" },
                    { "ba1ce8b4-7d6c-452d-873e-8b683f4bbbef", 0, "1c5e7b69-d549-4b33-a083-6988af8e780b", "emily.davis@onlybytes.com", "emily.davis@onlybytes.com", false, 5, "Emily", 2, "Davis", false, null, "EMILY.DAVIS@ONLYBYTES.COM", "EMILY.DAVIS@ONLYBYTES.COM", null, null, false, "d105be7e-4d05-43b9-bb8c-7b600521c799", 2, false, "emily.davis@onlybytes.com" },
                    { "dfede861-27ca-47ed-96c1-ed54c670ce4d", 0, "3666b496-6617-435c-a52c-697675fb44f2", "daniel.thompson@onlybytes.com", "daniel.thompson@onlybytes.com", false, 13, "Daniel", 2, "Thompson", false, null, "DANIEL.THOMPSON@ONLYBYTES.COM", "DANIEL.THOMPSON@ONLYBYTES.COM", null, null, false, "eef6652b-06dd-4c0c-87f7-854b06f5c6f0", 3, false, "daniel.thompson@onlybytes.com" },
                    { "e3ab6ce6-0aa6-4875-b7d6-48c0ed3ea37b", 0, "39e4f355-9326-42b4-a800-475c484ed930", "jane.smith@onlybytes.com", "jane.smith@onlybytes.com", false, 3, "Jane", 2, "Smith", false, null, "JANE.SMITH@ONLYBYTES.COM", "JANE.SMITH@ONLYBYTES.COM", null, null, false, "07e8b43e-be3f-4227-aacf-9dd6ee8c8fc1", 2, false, "jane.smith@onlybytes.com" }
                });

            migrationBuilder.InsertData(
                table: "ShiftAssignments",
                columns: new[] { "EmployeeId", "ShiftDate", "ShiftId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 19, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 20, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 20, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 21, new DateTime(2025, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2025, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, new DateTime(2025, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 1, 2, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 1, 3, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 1, 4, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 1, 5, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 2, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 2, 2, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 2, 3, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 2, 4, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 2, 5, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 3, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 3, 2, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 3, 3, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 4, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 4, 2, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 4, 3, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[] { 5, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[,]
                {
                    { 5, 2, null },
                    { 5, 3, null }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 6, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 6, 4, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 7, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 7, 4, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 8, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 8, 4, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 9, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 9, 5, true, new DateTime(2025, 2, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 10, 1, true, new DateTime(2025, 1, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 10, 5, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 11, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 11, 2, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 11, 3, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 11, 4, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 11, 5, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 12, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 12, 2, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 12, 3, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 12, 4, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 12, 5, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 13, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 13, 2, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 13, 3, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 14, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 14, 2, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 14, 3, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 15, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 15, 2, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 15, 3, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[] { 16, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[,]
                {
                    { 16, 2, null },
                    { 16, 3, null }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 17, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 17, 4, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 18, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 18, 4, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 19, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 19, 4, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 20, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 20, 4, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[,]
                {
                    { 21, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 21, 5, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) },
                    { 22, 1, true, new DateTime(2025, 3, 12, 17, 0, 56, 517, DateTimeKind.Local).AddTicks(1215) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 22, 5, null });

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
                name: "IX_AspNetUsers_EmailAddress",
                table: "AspNetUsers",
                column: "EmailAddress",
                unique: true);

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
