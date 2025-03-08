using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TourManagerment.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourGuides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourGuides_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourGuideId = table.Column<int>(type: "int", nullable: true),
                    TransportationMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_TourGuides_TourGuideId",
                        column: x => x.TourGuideId,
                        principalTable: "TourGuides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TourOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    TourID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourOrders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourOrders_Tours_TourID",
                        column: x => x.TourID,
                        principalTable: "Tours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_TourOrders_TourOrderID",
                        column: x => x.TourOrderID,
                        principalTable: "TourOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Hà Nội", "Nguyễn Văn A", "0987654321" },
                    { 2, "TP Hồ Chí Minh", "Trần Thị B", "0976543210" },
                    { 3, "Đà Nẵng", "Lê Văn C", "0965432109" },
                    { 4, "Hải Phòng", "Phạm Văn D", "0954321098" },
                    { 5, "Cần Thơ", "Hoàng Thị E", "0943210987" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TourOrderID",
                table: "Invoices",
                column: "TourOrderID",
                unique: true,
                filter: "[TourOrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TourGuides_UserId",
                table: "TourGuides",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourOrders_CustomerID",
                table: "TourOrders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TourOrders_TourID",
                table: "TourOrders",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourGuideId",
                table: "Tours",
                column: "TourGuideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "TourOrders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "TourGuides");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
