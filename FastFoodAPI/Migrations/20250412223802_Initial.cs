using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "23, 1"),
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
                    { "0d227b88-6eb1-4438-8580-04d00c5eed91", 0, "ea4b0057-9a1c-4735-9786-f460e4e4ebe9", "james.wilson@onlybytes.com", "james.wilson@onlybytes.com", false, 17, "James", 3, "Wilson", false, null, "JAMES.WILSON@ONLYBYTES.COM", "JAMES.WILSON@ONLYBYTES.COM", null, null, false, "84bb55f4-ac6a-4940-af71-1c9804502f5e", 4, false, "james.wilson@onlybytes.com" },
                    { "19a2b2cc-7c17-4bd4-b91e-8d55c00e063d", 0, "dd4cae66-b801-4af5-a9ea-bc0ecadb37e3", "jane.smith@onlybytes.com", "jane.smith@onlybytes.com", false, 3, "Jane", 2, "Smith", false, null, "JANE.SMITH@ONLYBYTES.COM", "JANE.SMITH@ONLYBYTES.COM", null, null, false, "26f79156-5842-4879-ad17-451a31fa8849", 2, false, "jane.smith@onlybytes.com" },
                    { "1a335340-e7d8-48d8-bd80-4ff9fda0dcbf", 0, "86024177-a6d6-4bc6-8661-599ced5e860f", "carlos.gomez@onlybytes.com", "carlos.gomez@onlybytes.com", false, 21, "Carlos", 4, "Gomez", false, null, "CARLOS.GOMEZ@ONLYBYTES.COM", "CARLOS.GOMEZ@ONLYBYTES.COM", null, null, false, "b35bd353-7718-475c-960e-d89605d80ff5", 7, false, "carlos.gomez@onlybytes.com" },
                    { "1da14681-ea09-44ad-ac1e-e27d242cd490", 0, "a6c844e1-24a4-4e90-89ce-e2f6cd7fb440", "david.garcia@onlybytes.com", "david.garcia@onlybytes.com", false, 7, "David", 3, "Garcia", false, null, "DAVID.GARCIA@ONLYBYTES.COM", "DAVID.GARCIA@ONLYBYTES.COM", null, null, false, "703b3d00-44ba-4e7d-b453-f520a705a08e", 5, false, "david.garcia@onlybytes.com" },
                    { "21d43ab8-c898-419d-8f5b-382f1588d34c", 0, "9efd9a0a-fafb-481c-ac0b-3b53e970dbe7", "sarah.johnson@onlybytes.com", "sarah.johnson@onlybytes.com", false, 2, "Sarah", 1, "Johnson", false, null, "SARAH.JOHNSON@ONLYBYTES.COM", "SARAH.JOHNSON@ONLYBYTES.COM", null, null, false, "0f72fed6-78cd-4f6c-b602-46e3ea5b3639", 1, false, "sarah.johnson@onlybytes.com" },
                    { "25c79549-deec-4634-9f58-9e84de04078b", 0, "6b956108-ee8a-4692-97ac-99f8ece08fe0", "thomas.lee@onlybytes.com", "thomas.lee@onlybytes.com", false, 15, "Thomas", 2, "Lee", false, null, "THOMAS.LEE@ONLYBYTES.COM", "THOMAS.LEE@ONLYBYTES.COM", null, null, false, "8f6ecf37-eba9-44ad-b281-3ec77f2c6138", 3, false, "thomas.lee@onlybytes.com" },
                    { "27cf17b5-2d70-4a9d-8e08-f03243f4b718", 0, "4a6f91eb-53e6-4a03-b0e4-ca37d99225d8", "emily.davis@onlybytes.com", "emily.davis@onlybytes.com", false, 5, "Emily", 2, "Davis", false, null, "EMILY.DAVIS@ONLYBYTES.COM", "EMILY.DAVIS@ONLYBYTES.COM", null, null, false, "020b1f37-d49b-49ad-af27-79b7307cf6ca", 2, false, "emily.davis@onlybytes.com" },
                    { "2ed2f0db-067b-4364-a496-bcc0b89cebbf", 0, "0f1e9025-363e-4255-98de-f7a1c753e3a6", "robert.taylor@onlybytes.com", "robert.taylor@onlybytes.com", false, 9, "Robert", 4, "Taylor", false, null, "ROBERT.TAYLOR@ONLYBYTES.COM", "ROBERT.TAYLOR@ONLYBYTES.COM", null, null, false, "3b855616-302d-4261-a14d-4c9ab0c5cd4c", 7, false, "robert.taylor@onlybytes.com" },
                    { "2fb2f0ea-c258-4c9a-9561-ee4dd3785d4a", 0, "b95f1d12-fa46-4c78-942d-0e7444cb84da", "kevin.kim@onlybytes.com", "kevin.kim@onlybytes.com", false, 19, "Kevin", 3, "Kim", false, null, "KEVIN.KIM@ONLYBYTES.COM", "KEVIN.KIM@ONLYBYTES.COM", null, null, false, "ad5bb9f0-c4d0-4dd4-8157-164ce3744a46", 6, false, "kevin.kim@onlybytes.com" },
                    { "33fff383-2085-4f2c-87cc-63b185dd5499", 0, "62b471df-279f-486d-b954-67b689ebc8eb", "mike.wilson@onlybytes.com", "mike.wilson@onlybytes.com", false, 6, "Mike", 3, "Wilson", false, null, "MIKE.WILSON@ONLYBYTES.COM", "MIKE.WILSON@ONLYBYTES.COM", null, null, false, "6adbba74-8c67-420d-9c01-4be9f3aae431", 4, false, "mike.wilson@onlybytes.com" },
                    { "3fec7fc0-938c-4912-aa8f-c2f6563a3ec7", 0, "37ce3550-d3d4-4200-b5f3-7a2d8b270d09", "jennifer.chen@onlybytes.com", "jennifer.chen@onlybytes.com", false, 20, "Jennifer", 3, "Chen", false, null, "JENNIFER.CHEN@ONLYBYTES.COM", "JENNIFER.CHEN@ONLYBYTES.COM", null, null, false, "33e19105-4ee9-4c5d-a423-68d31a772bb5", 4, false, "jennifer.chen@onlybytes.com" },
                    { "4695fa54-99ec-42c6-8dc2-1596acd6ebb0", 0, "5f9e2eec-e11d-4c8d-817e-1185be3a7a01", "amanda.williams@onlybytes.com", "amanda.williams@onlybytes.com", false, 12, "Amanda", 1, "Williams", false, null, "AMANDA.WILLIAMS@ONLYBYTES.COM", "AMANDA.WILLIAMS@ONLYBYTES.COM", null, null, false, "88b7ffb5-4239-4977-a367-72f2414ebcaa", 1, false, "amanda.williams@onlybytes.com" },
                    { "473a1ee3-f385-45bb-be39-b25a4778eb1f", 0, "4676e3a2-5470-4f17-ae4f-c4d49412808a", "maria.hernandez@onlybytes.com", "maria.hernandez@onlybytes.com", false, 18, "Maria", 3, "Hernandez", false, null, "MARIA.HERNANDEZ@ONLYBYTES.COM", "MARIA.HERNANDEZ@ONLYBYTES.COM", null, null, false, "2e74d2a2-27c2-44af-95e0-5eeb56646199", 5, false, "maria.hernandez@onlybytes.com" },
                    { "4e19a5ae-5b6c-4ec3-8d10-183c4d0fb5af", 0, "c4d1dc40-039b-49d1-9422-480d87d5ae15", "olivia.rodriguez@onlybytes.com", "olivia.rodriguez@onlybytes.com", false, 14, "Olivia", 2, "Rodriguez", false, null, "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", "OLIVIA.RODRIGUEZ@ONLYBYTES.COM", null, null, false, "984140db-698f-4bcf-906e-a55a561a5349", 2, false, "olivia.rodriguez@onlybytes.com" },
                    { "59e4f81a-c95a-415b-8da8-74a69f7a4c29", 0, "266fd4d8-8d42-44b0-ba9f-ac7e0f3ba189", "jessica.martinez@onlybytes.com", "jessica.martinez@onlybytes.com", false, 8, "Jessica", 3, "Martinez", false, null, "JESSICA.MARTINEZ@ONLYBYTES.COM", "JESSICA.MARTINEZ@ONLYBYTES.COM", null, null, false, "0661fae9-de80-451a-8cb2-f01e64adb645", 6, false, "jessica.martinez@onlybytes.com" },
                    { "8ea172e8-0c9e-4b77-acbb-788a74c65c41", 0, "763adb83-5624-4696-83c9-3f05143b2855", "daniel.thompson@onlybytes.com", "daniel.thompson@onlybytes.com", false, 13, "Daniel", 2, "Thompson", false, null, "DANIEL.THOMPSON@ONLYBYTES.COM", "DANIEL.THOMPSON@ONLYBYTES.COM", null, null, false, "6b6d7ac2-5bc1-4155-b686-c3ec7698669e", 3, false, "daniel.thompson@onlybytes.com" },
                    { "92174d13-8e7c-498a-9e78-195563192bf3", 0, "fe239151-6c1d-47da-a972-10c9d7a40b7a", "sophia.patel@onlybytes.com", "sophia.patel@onlybytes.com", false, 16, "Sophia", 2, "Patel", false, null, "SOPHIA.PATEL@ONLYBYTES.COM", "SOPHIA.PATEL@ONLYBYTES.COM", null, null, false, "4c32dcee-6ffc-4c53-8e3d-47ab4ed353b8", 2, false, "sophia.patel@onlybytes.com" },
                    { "94a7ca42-3064-425c-9549-e20d1ac29206", 0, "2c5a1336-cd71-4e20-8f4b-ccd7a1d08499", "john.doe@onlybytes.com", "john.doe@onlybytes.com", false, 1, "John", 1, "Doe", false, null, "JOHN.DOE@ONLYBYTES.COM", "JOHN.DOE@ONLYBYTES.COM", null, null, false, "e626411a-c279-41b6-812e-3b5d253410c2", 1, false, "john.doe@onlybytes.com" },
                    { "99882246-5ed3-4fab-b5b4-dff32b4dd6a8", 0, "664f7be8-7d3c-45d8-add3-61ee9a0be293", "emma.wright@onlybytes.com", "emma.wright@onlybytes.com", false, 22, "Emma", 4, "Wright", false, null, "EMMA.WRIGHT@ONLYBYTES.COM", "EMMA.WRIGHT@ONLYBYTES.COM", null, null, false, "6229e21b-5c78-4895-8c8d-3bd1a19f93cc", 7, false, "emma.wright@onlybytes.com" },
                    { "a495ac23-4e21-41a2-a8e4-c260bad946fe", 0, "667cd2d4-0639-4298-8387-1f9d6c5103a7", "michael.brown@onlybytes.com", "michael.brown@onlybytes.com", false, 4, "Michael", 2, "Brown", false, null, "MICHAEL.BROWN@ONLYBYTES.COM", "MICHAEL.BROWN@ONLYBYTES.COM", null, null, false, "e4f7bc80-c8a5-456d-88db-6416f5a21537", 3, false, "michael.brown@onlybytes.com" },
                    { "b5a893cf-8caf-49d3-b1b9-c8ef8118c22e", 0, "2ec3026e-4a0b-4c05-9f8e-61a45b7d640b", "richard.parker@onlybytes.com", "richard.parker@onlybytes.com", false, 11, "Richard", 1, "Parker", false, null, "RICHARD.PARKER@ONLYBYTES.COM", "RICHARD.PARKER@ONLYBYTES.COM", null, null, false, "fd35d77c-b9a2-4736-bdc8-0d75adaf1183", 1, false, "richard.parker@onlybytes.com" },
                    { "eef78775-5b70-4099-90d0-a9a5902632f2", 0, "0aad47a2-6f63-493c-b8d5-cdf7f467d2b1", "lisa.anderson@onlybytes.com", "lisa.anderson@onlybytes.com", false, 10, "Lisa", 4, "Anderson", false, null, "LISA.ANDERSON@ONLYBYTES.COM", "LISA.ANDERSON@ONLYBYTES.COM", null, null, false, "33bfbb1d-7c7b-4213-9fb1-4e870be860a3", 7, false, "lisa.anderson@onlybytes.com" }
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
                    { 1, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 1, 2, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 1, 3, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 1, 4, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 1, 5, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 2, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 2, 2, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 2, 3, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 2, 4, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 2, 5, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 3, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 3, 2, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 3, 3, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 4, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 4, 2, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 4, 3, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[] { 5, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) });

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
                    { 6, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 6, 4, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 7, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 7, 4, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 8, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
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
                    { 9, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 9, 5, true, new DateTime(2025, 2, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 10, 1, true, new DateTime(2025, 1, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
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
                    { 11, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 11, 2, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 11, 3, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 11, 4, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 11, 5, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 12, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 12, 2, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 12, 3, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 12, 4, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 12, 5, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 13, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 13, 2, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 13, 3, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 14, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 14, 2, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 14, 3, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 15, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 15, 2, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
                });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "DateCompleted" },
                values: new object[] { 15, 3, null });

            migrationBuilder.InsertData(
                table: "TrainingAssignments",
                columns: new[] { "EmployeeId", "TrainingId", "CompletedTraining", "DateCompleted" },
                values: new object[] { 16, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) });

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
                    { 17, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 17, 4, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 18, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 18, 4, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 19, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 19, 4, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 20, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
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
                    { 21, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 21, 5, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) },
                    { 22, 1, true, new DateTime(2025, 3, 12, 18, 38, 2, 4, DateTimeKind.Local).AddTicks(588) }
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
