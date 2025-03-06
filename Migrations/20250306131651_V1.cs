using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tours",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", "admin", "admin" },
                    { 2, "nhanvien", "employee", "nhanvien" },
                    { 3, "nhanvien1", "employee", "nhanvien1" }
                });

            migrationBuilder.InsertData(
                table: "TourGuides",
                columns: new[] { "Id", "Birthday", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Văn A", "0987654321", 1 },
                    { 2, new DateTime(1990, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trần Thị B", "0976543210", 2 },
                    { 3, new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Văn C", "0965432109", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Cost", "Duration", "EndDate", "Name", "Pics", "StartDate", "TourGuideId", "TransportationMethod", "Type" },
                values: new object[,]
                {
                    { 1, 5000000m, 3, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Đà Nẵng - Bà Nà Hills", "danang.jpg", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Máy bay", "Cao cấp" },
                    { 2, 7000000m, 4, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Phú Quốc - Biển xanh", "phuquoc.jpg", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Tiêu chuẩn" },
                    { 3, 3000000m, 2, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Hà Nội - Hạ Long", "halong.jpg", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiết kiệm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tours",
                newName: "ID");
        }
    }
}
