using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class SeedTourData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "ID", "Cost", "Duration", "EndDate", "Name", "Pics", "StartDate", "TourGuideID", "TransportationMethod", "Type" },
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
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
