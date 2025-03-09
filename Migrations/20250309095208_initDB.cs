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
                    { 5, "Cần Thơ", "Hoàng Thị E", "0943210987" },
                    { 6, "Hà Nội", "Vũ Minh F", "0932109876" },
                    { 7, "Đà Nẵng", "Đỗ Thanh G", "0921098765" },
                    { 8, "Hải Phòng", "Nguyễn Văn H", "0910987654" },
                    { 9, "Cần Thơ", "Trần Thị I", "0909876543" },
                    { 10, "TP Hồ Chí Minh", "Lê Văn J", "0898765432" },
                    { 11, "Hà Nội", "Nguyễn Văn K", "0987123456" },
                    { 12, "TP Hồ Chí Minh", "Trần Thị L", "0978123456" },
                    { 13, "Đà Nẵng", "Lê Văn M", "0969123456" },
                    { 14, "Hải Phòng", "Phạm Văn N", "0956123456" },
                    { 15, "Cần Thơ", "Hoàng Thị O", "0945123456" },
                    { 16, "Hà Nội", "Vũ Minh P", "0934123456" },
                    { 17, "Đà Nẵng", "Đỗ Thanh Q", "0923123456" },
                    { 18, "Hải Phòng", "Nguyễn Văn R", "0912123456" },
                    { 19, "Cần Thơ", "Trần Thị S", "0901123456" },
                    { 20, "TP Hồ Chí Minh", "Lê Văn T", "0899123456" },
                    { 21, "Hà Nội", "Phạm Thị U", "0888123456" },
                    { 22, "Đà Nẵng", "Hoàng Văn V", "0877123456" },
                    { 23, "Hải Phòng", "Vũ Thị W", "0866123456" },
                    { 24, "Cần Thơ", "Đỗ Minh X", "0855123456" },
                    { 25, "TP Hồ Chí Minh", "Nguyễn Thị Y", "0844123456" },
                    { 26, "Hà Nội", "Trần Văn Z", "0833123456" },
                    { 27, "Đà Nẵng", "Lê Thị A1", "0822123456" },
                    { 28, "Hải Phòng", "Phạm Văn B1", "0811123456" },
                    { 29, "Cần Thơ", "Hoàng Văn C1", "0800123456" },
                    { 30, "TP Hồ Chí Minh", "Vũ Minh D1", "0799123456" },
                    { 31, "Hà Nội", "Nguyễn Văn E1", "0788123456" },
                    { 32, "TP Hồ Chí Minh", "Trần Thị F1", "0777123456" },
                    { 33, "Đà Nẵng", "Lê Văn G1", "0766123456" },
                    { 34, "Hải Phòng", "Phạm Văn H1", "0755123456" },
                    { 35, "Cần Thơ", "Hoàng Thị I1", "0744123456" },
                    { 36, "Hà Nội", "Vũ Minh J1", "0733123456" },
                    { 37, "Đà Nẵng", "Đỗ Thanh K1", "0722123456" },
                    { 38, "Hải Phòng", "Nguyễn Văn L1", "0711123456" },
                    { 39, "Cần Thơ", "Trần Thị M1", "0700123456" },
                    { 40, "TP Hồ Chí Minh", "Lê Văn N1", "0699123456" },
                    { 41, "Hà Nội", "Phạm Thị O1", "0688123456" },
                    { 42, "Đà Nẵng", "Hoàng Văn P1", "0677123456" },
                    { 43, "Hải Phòng", "Vũ Thị Q1", "0666123456" },
                    { 44, "Cần Thơ", "Đỗ Minh R1", "0655123456" },
                    { 45, "TP Hồ Chí Minh", "Nguyễn Thị S1", "0644123456" },
                    { 46, "Hà Nội", "Trần Văn T1", "0633123456" },
                    { 47, "Đà Nẵng", "Lê Thị U1", "0622123456" },
                    { 48, "Hải Phòng", "Phạm Văn V1", "0611123456" },
                    { 49, "Cần Thơ", "Hoàng Văn W1", "0600123456" },
                    { 50, "TP Hồ Chí Minh", "Vũ Minh X1", "0599123456" }
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
                    { 1, 5000000m, 3, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Đà Nẵng - Bà Nà Hills", "danang.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Máy bay", "Cao cấp" },
                    { 2, 7000000m, 4, new DateTime(2023, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Phú Quốc - Biển xanh", "phuquoc.jpg", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Tiêu chuẩn" },
                    { 3, 3000000m, 2, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Hà Nội - Hạ Long", "halong.jpg", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiết kiệm" },
                    { 4, 6500000m, 3, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Sapa - Fansipan", "sapa.jpg", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Cao cấp" },
                    { 5, 4000000m, 2, new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Hội An - Mỹ Sơn", "hoian.jpg", new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Xe khách", "Tiêu chuẩn" },
                    { 6, 7500000m, 3, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Nha Trang - Vinpearl", "nhatrang.jpg", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Máy bay", "Cao cấp" },
                    { 7, 3500000m, 2, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Cần Thơ - Chợ nổi Cái Răng", "cantho.jpg", new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Tiết kiệm" },
                    { 8, 4200000m, 2, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Huế - Đại Nội", "hue.jpg", new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Xe khách", "Tiêu chuẩn" },
                    { 9, 2800000m, 3, new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Bến Tre - Sông nước miền Tây", "bentre.jpg", new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiết kiệm" },
                    { 10, 8000000m, 3, new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Cà Mau - Mũi Cà Mau", "camau.jpg", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Máy bay", "Cao cấp" },
                    { 11, 6000000m, 4, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Tây Nguyên - Buôn Ma Thuột", "taynguyen.jpg", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Cao cấp" },
                    { 12, 4500000m, 3, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Mộc Châu - Cao nguyên xanh", "mocchau.jpg", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiêu chuẩn" },
                    { 13, 3200000m, 2, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Vũng Tàu - Biển đẹp", "vungtau.jpg", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Tiết kiệm" },
                    { 14, 7000000m, 5, new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Hà Giang - Cao nguyên đá", "hagiang.jpg", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Xe khách", "Cao cấp" },
                    { 15, 4800000m, 3, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Bình Thuận - Mũi Né", "muine.jpg", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiêu chuẩn" },
                    { 16, 7500000m, 4, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Quảng Bình - Phong Nha Kẻ Bàng", "quangbinh.jpg", new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Máy bay", "Cao cấp" },
                    { 17, 4000000m, 3, new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Lý Sơn - Đảo thiên đường", "lyson.jpg", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tàu thủy", "Tiết kiệm" },
                    { 18, 3500000m, 2, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Đồng Tháp - Làng hoa Sa Đéc", "sa-dec.jpg", new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiêu chuẩn" },
                    { 19, 5200000m, 2, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Ninh Bình - Tràng An", "ninhbinh.jpg", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Cao cấp" },
                    { 20, 8500000m, 3, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Côn Đảo - Di tích lịch sử", "condao.jpg", new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Cao cấp" },
                    { 21, 6500000m, 4, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Sapa - Núi Fansipan", "sapa.jpg", new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Cao cấp" },
                    { 22, 5000000m, 3, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Huế - Cố đô", "hue.jpg", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Tiêu chuẩn" },
                    { 23, 7000000m, 5, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Cà Mau - Mũi Cà Mau", "camau.jpg", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Cao cấp" },
                    { 24, 4000000m, 3, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Đà Lạt - Thành phố ngàn hoa", "dalat.jpg", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiết kiệm" },
                    { 25, 7500000m, 4, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Nha Trang - Đảo Bình Ba", "nhatrang.jpg", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Cao cấp" },
                    { 26, 4800000m, 3, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Hà Tiên - Biển đảo", "hatien.jpg", new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Tiêu chuẩn" },
                    { 27, 3000000m, 2, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Tây Ninh - Núi Bà Đen", "tayninh.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiết kiệm" },
                    { 28, 6800000m, 4, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Quy Nhơn - Eo Gió", "quynhon.jpg", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Máy bay", "Cao cấp" },
                    { 29, 3500000m, 2, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Cần Thơ - Chợ nổi Cái Răng", "cantho.jpg", new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Xe khách", "Tiết kiệm" },
                    { 30, 4200000m, 3, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tour Bắc Kạn - Hồ Ba Bể", "babebe.jpg", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Xe khách", "Tiêu chuẩn" }
                });

            migrationBuilder.InsertData(
                table: "TourOrders",
                columns: new[] { "Id", "CreationTime", "CustomerID", "Status", "TourID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Complete", 1 },
                    { 2, new DateTime(2023, 1, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, "Complete", 2 },
                    { 3, new DateTime(2023, 2, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, "Complete", 3 },
                    { 4, new DateTime(2023, 2, 15, 16, 45, 0, 0, DateTimeKind.Unspecified), 4, "Complete", 4 },
                    { 5, new DateTime(2023, 3, 1, 11, 20, 0, 0, DateTimeKind.Unspecified), 5, "Complete", 5 },
                    { 6, new DateTime(2023, 3, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 6, "Complete", 6 },
                    { 7, new DateTime(2023, 4, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 7, "Complete", 7 },
                    { 8, new DateTime(2023, 4, 15, 8, 45, 0, 0, DateTimeKind.Unspecified), 8, "Complete", 8 },
                    { 9, new DateTime(2023, 5, 1, 12, 10, 0, 0, DateTimeKind.Unspecified), 9, "Complete", 9 },
                    { 10, new DateTime(2023, 5, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 10, "Complete", 10 },
                    { 11, new DateTime(2023, 6, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 11, "Complete", 11 },
                    { 12, new DateTime(2023, 6, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 12, "Complete", 12 },
                    { 13, new DateTime(2023, 7, 1, 10, 45, 0, 0, DateTimeKind.Unspecified), 13, "Complete", 13 },
                    { 14, new DateTime(2023, 7, 15, 16, 15, 0, 0, DateTimeKind.Unspecified), 14, "Complete", 14 },
                    { 15, new DateTime(2023, 8, 1, 11, 50, 0, 0, DateTimeKind.Unspecified), 15, "Complete", 15 },
                    { 16, new DateTime(2023, 8, 15, 13, 20, 0, 0, DateTimeKind.Unspecified), 16, "Complete", 16 },
                    { 17, new DateTime(2023, 9, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 17, "Complete", 17 },
                    { 18, new DateTime(2023, 9, 15, 9, 15, 0, 0, DateTimeKind.Unspecified), 18, "Complete", 18 },
                    { 19, new DateTime(2023, 10, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 19, "Complete", 19 },
                    { 20, new DateTime(2023, 10, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), 20, "Complete", 20 },
                    { 21, new DateTime(2023, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 21, "Complete", 21 },
                    { 22, new DateTime(2023, 11, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 22, "Complete", 22 },
                    { 23, new DateTime(2023, 12, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), 23, "Complete", 23 },
                    { 24, new DateTime(2023, 12, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), 24, "Complete", 24 },
                    { 25, new DateTime(2024, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 25, "Complete", 25 },
                    { 26, new DateTime(2024, 1, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 26, "Complete", 26 },
                    { 27, new DateTime(2024, 2, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 27, "Complete", 27 },
                    { 28, new DateTime(2024, 2, 15, 16, 15, 0, 0, DateTimeKind.Unspecified), 28, "Complete", 28 },
                    { 29, new DateTime(2024, 3, 1, 10, 45, 0, 0, DateTimeKind.Unspecified), 29, "Complete", 29 },
                    { 30, new DateTime(2024, 3, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 30, "Complete", 30 },
                    { 31, new DateTime(2024, 4, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 31, "Complete", 1 },
                    { 32, new DateTime(2024, 4, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 32, "Complete", 2 },
                    { 33, new DateTime(2024, 5, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 33, "Complete", 3 },
                    { 34, new DateTime(2024, 5, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), 34, "Complete", 4 },
                    { 35, new DateTime(2024, 6, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 35, "Complete", 5 },
                    { 36, new DateTime(2024, 6, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 36, "Complete", 6 },
                    { 37, new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 37, "Complete", 7 },
                    { 38, new DateTime(2024, 7, 15, 12, 15, 0, 0, DateTimeKind.Unspecified), 38, "Complete", 8 },
                    { 39, new DateTime(2024, 8, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), 39, "Complete", 9 },
                    { 40, new DateTime(2024, 8, 15, 16, 30, 0, 0, DateTimeKind.Unspecified), 40, "Complete", 10 },
                    { 41, new DateTime(2024, 9, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 41, "Complete", 11 },
                    { 42, new DateTime(2024, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 42, "Complete", 12 },
                    { 43, new DateTime(2024, 10, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), 43, "Complete", 13 },
                    { 44, new DateTime(2024, 10, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), 44, "Complete", 14 },
                    { 45, new DateTime(2024, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, "Complete", 15 },
                    { 46, new DateTime(2024, 11, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), 46, "Complete", 16 },
                    { 47, new DateTime(2024, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 47, "Complete", 17 },
                    { 48, new DateTime(2024, 12, 15, 16, 15, 0, 0, DateTimeKind.Unspecified), 48, "Complete", 18 },
                    { 49, new DateTime(2025, 1, 1, 9, 45, 0, 0, DateTimeKind.Unspecified), 49, "Complete", 19 },
                    { 50, new DateTime(2025, 1, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), 50, "Complete", 20 },
                    { 51, new DateTime(2023, 2, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "Complete", 21 },
                    { 52, new DateTime(2023, 3, 20, 15, 15, 0, 0, DateTimeKind.Unspecified), 2, "Complete", 22 },
                    { 53, new DateTime(2023, 4, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 3, "Complete", 23 },
                    { 54, new DateTime(2023, 5, 20, 12, 45, 0, 0, DateTimeKind.Unspecified), 4, "Complete", 24 },
                    { 55, new DateTime(2023, 6, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, "Complete", 25 },
                    { 56, new DateTime(2023, 7, 20, 16, 30, 0, 0, DateTimeKind.Unspecified), 6, "Complete", 26 },
                    { 57, new DateTime(2023, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 7, "Complete", 27 },
                    { 58, new DateTime(2023, 9, 20, 11, 15, 0, 0, DateTimeKind.Unspecified), 8, "Complete", 28 },
                    { 59, new DateTime(2023, 10, 10, 13, 45, 0, 0, DateTimeKind.Unspecified), 9, "Complete", 29 },
                    { 60, new DateTime(2023, 11, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 10, "Complete", 30 },
                    { 61, new DateTime(2023, 12, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 11, "Complete", 1 },
                    { 62, new DateTime(2024, 1, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), 12, "Complete", 2 },
                    { 63, new DateTime(2024, 2, 10, 14, 15, 0, 0, DateTimeKind.Unspecified), 13, "Complete", 3 },
                    { 64, new DateTime(2024, 3, 20, 16, 45, 0, 0, DateTimeKind.Unspecified), 14, "Complete", 4 },
                    { 65, new DateTime(2024, 4, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 15, "Complete", 5 },
                    { 66, new DateTime(2024, 5, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 16, "Complete", 6 },
                    { 67, new DateTime(2024, 6, 10, 13, 15, 0, 0, DateTimeKind.Unspecified), 17, "Complete", 7 },
                    { 68, new DateTime(2024, 7, 20, 15, 45, 0, 0, DateTimeKind.Unspecified), 18, "Complete", 8 },
                    { 69, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 19, "Complete", 9 },
                    { 70, new DateTime(2024, 9, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), 20, "Complete", 10 },
                    { 71, new DateTime(2024, 10, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 21, "Complete", 11 },
                    { 72, new DateTime(2024, 11, 20, 16, 15, 0, 0, DateTimeKind.Unspecified), 22, "Complete", 12 },
                    { 73, new DateTime(2024, 12, 10, 9, 45, 0, 0, DateTimeKind.Unspecified), 23, "Complete", 13 },
                    { 74, new DateTime(2025, 1, 20, 11, 30, 0, 0, DateTimeKind.Unspecified), 24, "Complete", 14 },
                    { 75, new DateTime(2025, 2, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 25, "Complete", 15 },
                    { 76, new DateTime(2025, 2, 15, 15, 15, 0, 0, DateTimeKind.Unspecified), 26, "Complete", 16 },
                    { 77, new DateTime(2023, 3, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), 27, "Complete", 17 },
                    { 78, new DateTime(2023, 4, 20, 12, 45, 0, 0, DateTimeKind.Unspecified), 28, "Complete", 18 },
                    { 79, new DateTime(2023, 5, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 29, "Complete", 19 },
                    { 80, new DateTime(2023, 6, 20, 16, 30, 0, 0, DateTimeKind.Unspecified), 30, "Complete", 20 },
                    { 81, new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 31, "Pending", 21 },
                    { 82, new DateTime(2025, 3, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 32, "Pending", 22 },
                    { 83, new DateTime(2025, 3, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 33, "Pending", 23 },
                    { 84, new DateTime(2025, 3, 2, 16, 15, 0, 0, DateTimeKind.Unspecified), 34, "Pending", 24 },
                    { 85, new DateTime(2025, 3, 3, 9, 45, 0, 0, DateTimeKind.Unspecified), 35, "Pending", 25 },
                    { 86, new DateTime(2025, 3, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 36, "Pending", 26 },
                    { 87, new DateTime(2025, 3, 4, 13, 15, 0, 0, DateTimeKind.Unspecified), 37, "Pending", 27 },
                    { 88, new DateTime(2025, 3, 4, 15, 30, 0, 0, DateTimeKind.Unspecified), 38, "Pending", 28 },
                    { 89, new DateTime(2025, 3, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 39, "Pending", 29 },
                    { 90, new DateTime(2025, 3, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), 40, "Pending", 30 },
                    { 91, new DateTime(2025, 3, 6, 14, 45, 0, 0, DateTimeKind.Unspecified), 41, "Pending", 1 },
                    { 92, new DateTime(2025, 3, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), 42, "Pending", 2 },
                    { 93, new DateTime(2025, 3, 7, 9, 15, 0, 0, DateTimeKind.Unspecified), 43, "Pending", 3 },
                    { 94, new DateTime(2025, 3, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), 44, "Pending", 4 },
                    { 95, new DateTime(2025, 3, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), 45, "Pending", 5 },
                    { 96, new DateTime(2025, 3, 8, 15, 45, 0, 0, DateTimeKind.Unspecified), 46, "Pending", 6 },
                    { 97, new DateTime(2025, 3, 9, 10, 30, 0, 0, DateTimeKind.Unspecified), 47, "Pending", 7 },
                    { 98, new DateTime(2025, 3, 9, 12, 0, 0, 0, DateTimeKind.Unspecified), 48, "Pending", 8 },
                    { 99, new DateTime(2025, 3, 9, 14, 15, 0, 0, DateTimeKind.Unspecified), 49, "Pending", 9 },
                    { 100, new DateTime(2025, 3, 9, 16, 30, 0, 0, DateTimeKind.Unspecified), 50, "Pending", 10 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "TourOrderID", "amount", "createdAt" },
                values: new object[,]
                {
                    { 1, 1, 5000000L, new DateTime(2023, 1, 6, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 7000000L, new DateTime(2023, 1, 16, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3000000L, new DateTime(2023, 2, 2, 10, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 6500000L, new DateTime(2023, 2, 16, 16, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 4000000L, new DateTime(2023, 3, 2, 11, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 7500000L, new DateTime(2023, 3, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 3500000L, new DateTime(2023, 4, 2, 15, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 4200000L, new DateTime(2023, 4, 16, 8, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 2800000L, new DateTime(2023, 5, 2, 12, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 8000000L, new DateTime(2023, 5, 16, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, 6000000L, new DateTime(2023, 6, 2, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 12, 4500000L, new DateTime(2023, 6, 16, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 13, 3200000L, new DateTime(2023, 7, 2, 10, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 14, 7000000L, new DateTime(2023, 7, 16, 16, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 15, 4800000L, new DateTime(2023, 8, 2, 11, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 16, 7500000L, new DateTime(2023, 8, 16, 13, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 17, 4000000L, new DateTime(2023, 9, 2, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 18, 3500000L, new DateTime(2023, 9, 16, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 19, 5200000L, new DateTime(2023, 10, 2, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 20, 8500000L, new DateTime(2023, 10, 16, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 21, 6500000L, new DateTime(2023, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 22, 5000000L, new DateTime(2023, 11, 16, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 23, 7000000L, new DateTime(2023, 12, 2, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 24, 4000000L, new DateTime(2023, 12, 16, 15, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 25, 7500000L, new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 26, 4800000L, new DateTime(2024, 1, 16, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 27, 3000000L, new DateTime(2024, 2, 2, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 28, 6800000L, new DateTime(2024, 2, 16, 16, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 29, 3500000L, new DateTime(2024, 3, 2, 10, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 30, 4200000L, new DateTime(2024, 3, 16, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 31, 5000000L, new DateTime(2024, 4, 2, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 32, 7000000L, new DateTime(2024, 4, 16, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 33, 3000000L, new DateTime(2024, 5, 2, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 34, 6500000L, new DateTime(2024, 5, 16, 11, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 35, 4000000L, new DateTime(2024, 6, 2, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 36, 7500000L, new DateTime(2024, 6, 16, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 37, 3500000L, new DateTime(2024, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 38, 4200000L, new DateTime(2024, 7, 16, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 39, 2800000L, new DateTime(2024, 8, 2, 14, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 40, 8000000L, new DateTime(2024, 8, 16, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 41, 6000000L, new DateTime(2024, 9, 2, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 42, 4500000L, new DateTime(2024, 9, 16, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 43, 3200000L, new DateTime(2024, 10, 2, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 44, 7000000L, new DateTime(2024, 10, 16, 15, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 45, 4800000L, new DateTime(2024, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 46, 7500000L, new DateTime(2024, 11, 16, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 47, 4000000L, new DateTime(2024, 12, 2, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 48, 3500000L, new DateTime(2024, 12, 16, 16, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 49, 5200000L, new DateTime(2025, 1, 2, 9, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 50, 8500000L, new DateTime(2025, 1, 16, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 51, 6500000L, new DateTime(2023, 2, 11, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 52, 5000000L, new DateTime(2023, 3, 21, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 53, 7000000L, new DateTime(2023, 4, 11, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 54, 4000000L, new DateTime(2023, 5, 21, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 55, 7500000L, new DateTime(2023, 6, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 56, 4800000L, new DateTime(2023, 7, 21, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 57, 3000000L, new DateTime(2023, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 58, 6800000L, new DateTime(2023, 9, 21, 11, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 59, 3500000L, new DateTime(2023, 10, 11, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 60, 4200000L, new DateTime(2023, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 61, 5000000L, new DateTime(2023, 12, 11, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 62, 7000000L, new DateTime(2024, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 63, 3000000L, new DateTime(2024, 2, 11, 14, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 64, 6500000L, new DateTime(2024, 3, 21, 16, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 65, 4000000L, new DateTime(2024, 4, 11, 9, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 66, 7500000L, new DateTime(2024, 5, 21, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 67, 3500000L, new DateTime(2024, 6, 11, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 68, 4200000L, new DateTime(2024, 7, 21, 15, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 69, 2800000L, new DateTime(2024, 8, 11, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 70, 8000000L, new DateTime(2024, 9, 21, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 71, 6000000L, new DateTime(2024, 10, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 72, 4500000L, new DateTime(2024, 11, 21, 16, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 73, 3200000L, new DateTime(2024, 12, 11, 9, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 74, 7000000L, new DateTime(2025, 1, 21, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 75, 4800000L, new DateTime(2025, 2, 2, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 76, 7500000L, new DateTime(2025, 2, 16, 15, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 77, 4000000L, new DateTime(2023, 3, 11, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 78, 3500000L, new DateTime(2023, 4, 21, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 79, 5200000L, new DateTime(2023, 5, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 80, 8500000L, new DateTime(2023, 6, 21, 16, 30, 0, 0, DateTimeKind.Unspecified) }
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
