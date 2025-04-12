using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "23, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 4, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 4, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 5, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 6, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 6, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 7, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 7, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 8, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 9, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 9, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 10, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 15, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 15, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 16, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 17, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 17, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 18, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 18, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 19, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 19, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 20, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 21, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 21, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 22, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 12, 13, 49, 35, 184, DateTimeKind.Local).AddTicks(2964));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "23, 1");

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 1, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 2, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 3, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 4, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 4, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 5, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 6, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 6, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 7, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 7, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 8, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 9, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 9, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 2, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 10, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 1, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 11, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 12, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 13, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 14, 3 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 15, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 15, 2 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 16, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 17, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 17, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 18, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 18, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 19, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 19, 4 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 20, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 21, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 21, 5 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "TrainingAssignments",
                keyColumns: new[] { "EmployeeId", "TrainingId" },
                keyValues: new object[] { 22, 1 },
                column: "DateCompleted",
                value: new DateTime(2025, 3, 8, 15, 42, 25, 660, DateTimeKind.Local).AddTicks(3679));
        }
    }
}
