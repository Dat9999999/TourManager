using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TourManagerment.Models;

namespace TourManagerment.Data
{
    public class MTourContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string? connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<TourOrder> TourOrders { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }

        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Nguyễn Văn A", Phone = "0987654321", Address = "Hà Nội" },
                new Customer { Id = 2, Name = "Trần Thị B", Phone = "0976543210", Address = "TP Hồ Chí Minh" },
                new Customer { Id = 3, Name = "Lê Văn C", Phone = "0965432109", Address = "Đà Nẵng" },
                new Customer { Id = 4, Name = "Phạm Văn D", Phone = "0954321098", Address = "Hải Phòng" },
                new Customer { Id = 5, Name = "Hoàng Thị E", Phone = "0943210987", Address = "Cần Thơ" },
                new Customer { Id = 6, Name = "Vũ Minh F", Phone = "0932109876", Address = "Hà Nội" },
                new Customer { Id = 7, Name = "Đỗ Thanh G", Phone = "0921098765", Address = "Đà Nẵng" },
                new Customer { Id = 8, Name = "Nguyễn Văn H", Phone = "0910987654", Address = "Hải Phòng" },
                new Customer { Id = 9, Name = "Trần Thị I", Phone = "0909876543", Address = "Cần Thơ" },
                new Customer { Id = 10, Name = "Lê Văn J", Phone = "0898765432", Address = "TP Hồ Chí Minh" },
                new Customer { Id = 11, Name = "Nguyễn Văn K", Phone = "0987123456", Address = "Hà Nội" },
            new Customer { Id = 12, Name = "Trần Thị L", Phone = "0978123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 13, Name = "Lê Văn M", Phone = "0969123456", Address = "Đà Nẵng" },
            new Customer { Id = 14, Name = "Phạm Văn N", Phone = "0956123456", Address = "Hải Phòng" },
            new Customer { Id = 15, Name = "Hoàng Thị O", Phone = "0945123456", Address = "Cần Thơ" },
            new Customer { Id = 16, Name = "Vũ Minh P", Phone = "0934123456", Address = "Hà Nội" },
            new Customer { Id = 17, Name = "Đỗ Thanh Q", Phone = "0923123456", Address = "Đà Nẵng" },
            new Customer { Id = 18, Name = "Nguyễn Văn R", Phone = "0912123456", Address = "Hải Phòng" },
            new Customer { Id = 19, Name = "Trần Thị S", Phone = "0901123456", Address = "Cần Thơ" },
            new Customer { Id = 20, Name = "Lê Văn T", Phone = "0899123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 21, Name = "Phạm Thị U", Phone = "0888123456", Address = "Hà Nội" },
            new Customer { Id = 22, Name = "Hoàng Văn V", Phone = "0877123456", Address = "Đà Nẵng" },
            new Customer { Id = 23, Name = "Vũ Thị W", Phone = "0866123456", Address = "Hải Phòng" },
            new Customer { Id = 24, Name = "Đỗ Minh X", Phone = "0855123456", Address = "Cần Thơ" },
            new Customer { Id = 25, Name = "Nguyễn Thị Y", Phone = "0844123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 26, Name = "Trần Văn Z", Phone = "0833123456", Address = "Hà Nội" },
            new Customer { Id = 27, Name = "Lê Thị A1", Phone = "0822123456", Address = "Đà Nẵng" },
            new Customer { Id = 28, Name = "Phạm Văn B1", Phone = "0811123456", Address = "Hải Phòng" },
            new Customer { Id = 29, Name = "Hoàng Văn C1", Phone = "0800123456", Address = "Cần Thơ" },
            new Customer { Id = 30, Name = "Vũ Minh D1", Phone = "0799123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 31, Name = "Nguyễn Văn E1", Phone = "0788123456", Address = "Hà Nội" },
            new Customer { Id = 32, Name = "Trần Thị F1", Phone = "0777123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 33, Name = "Lê Văn G1", Phone = "0766123456", Address = "Đà Nẵng" },
            new Customer { Id = 34, Name = "Phạm Văn H1", Phone = "0755123456", Address = "Hải Phòng" },
            new Customer { Id = 35, Name = "Hoàng Thị I1", Phone = "0744123456", Address = "Cần Thơ" },
            new Customer { Id = 36, Name = "Vũ Minh J1", Phone = "0733123456", Address = "Hà Nội" },
            new Customer { Id = 37, Name = "Đỗ Thanh K1", Phone = "0722123456", Address = "Đà Nẵng" },
            new Customer { Id = 38, Name = "Nguyễn Văn L1", Phone = "0711123456", Address = "Hải Phòng" },
            new Customer { Id = 39, Name = "Trần Thị M1", Phone = "0700123456", Address = "Cần Thơ" },
            new Customer { Id = 40, Name = "Lê Văn N1", Phone = "0699123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 41, Name = "Phạm Thị O1", Phone = "0688123456", Address = "Hà Nội" },
            new Customer { Id = 42, Name = "Hoàng Văn P1", Phone = "0677123456", Address = "Đà Nẵng" },
            new Customer { Id = 43, Name = "Vũ Thị Q1", Phone = "0666123456", Address = "Hải Phòng" },
            new Customer { Id = 44, Name = "Đỗ Minh R1", Phone = "0655123456", Address = "Cần Thơ" },
            new Customer { Id = 45, Name = "Nguyễn Thị S1", Phone = "0644123456", Address = "TP Hồ Chí Minh" },
            new Customer { Id = 46, Name = "Trần Văn T1", Phone = "0633123456", Address = "Hà Nội" },
            new Customer { Id = 47, Name = "Lê Thị U1", Phone = "0622123456", Address = "Đà Nẵng" },
            new Customer { Id = 48, Name = "Phạm Văn V1", Phone = "0611123456", Address = "Hải Phòng" },
            new Customer { Id = 49, Name = "Hoàng Văn W1", Phone = "0600123456", Address = "Cần Thơ" },
            new Customer { Id = 50, Name = "Vũ Minh X1", Phone = "0599123456", Address = "TP Hồ Chí Minh" }


            );

            modelBuilder.Entity<TourGuide>().HasData(
                new TourGuide
                {
                    Id = 1,
                    Name = "Nguyễn Văn A",
                    Birthday = new DateTime(1985, 6, 15),
                    PhoneNumber = "0987654321",
                    UserId = 1
                },
                new TourGuide
                {
                    Id = 2,
                    Name = "Trần Thị B",
                    Birthday = new DateTime(1990, 8, 25),
                    PhoneNumber = "0976543210",
                    UserId = 2
                },
                new TourGuide
                {
                    Id = 3,
                    Name = "Lê Văn C",
                    Birthday = new DateTime(1995, 3, 10),
                    PhoneNumber = "0965432109",
                    UserId = 3
                }
            );

            modelBuilder.Entity<Tour>().HasData(
                new Tour { Id = 1, Name = "Tour Đà Nẵng - Bà Nà Hills", Duration = 3, StartDate = new DateTime(2023, 3, 10), EndDate = new DateTime(2023, 3, 13), Type = "Cao cấp", Cost = 5000000, Pics = "danang.jpg", TourGuideId = 1, TransportationMethod = "Máy bay" },
                new Tour { Id = 2, Name = "Tour Phú Quốc - Biển xanh", Duration = 4, StartDate = new DateTime(2023, 4, 5), EndDate = new DateTime(2023, 4, 9), Type = "Tiêu chuẩn", Cost = 7000000, Pics = "phuquoc.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 3, Name = "Tour Hà Nội - Hạ Long", Duration = 2, StartDate = new DateTime(2023, 5, 1), EndDate = new DateTime(2023, 5, 3), Type = "Tiết kiệm", Cost = 3000000, Pics = "halong.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 4, Name = "Tour Sapa - Fansipan", Duration = 3, StartDate = new DateTime(2023, 6, 15), EndDate = new DateTime(2023, 6, 18), Type = "Cao cấp", Cost = 6500000, Pics = "sapa.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 5, Name = "Tour Hội An - Mỹ Sơn", Duration = 2, StartDate = new DateTime(2023, 7, 10), EndDate = new DateTime(2023, 7, 12), Type = "Tiêu chuẩn", Cost = 4000000, Pics = "hoian.jpg", TourGuideId = 2, TransportationMethod = "Xe khách" },
                new Tour { Id = 6, Name = "Tour Nha Trang - Vinpearl", Duration = 3, StartDate = new DateTime(2023, 8, 5), EndDate = new DateTime(2023, 8, 8), Type = "Cao cấp", Cost = 7500000, Pics = "nhatrang.jpg", TourGuideId = 3, TransportationMethod = "Máy bay" },
                new Tour { Id = 7, Name = "Tour Cần Thơ - Chợ nổi Cái Răng", Duration = 2, StartDate = new DateTime(2023, 9, 20), EndDate = new DateTime(2023, 9, 22), Type = "Tiết kiệm", Cost = 3500000, Pics = "cantho.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 8, Name = "Tour Huế - Đại Nội", Duration = 2, StartDate = new DateTime(2023, 10, 12), EndDate = new DateTime(2023, 10, 14), Type = "Tiêu chuẩn", Cost = 4200000, Pics = "hue.jpg", TourGuideId = 2, TransportationMethod = "Xe khách" },
                new Tour { Id = 9, Name = "Tour Bến Tre - Sông nước miền Tây", Duration = 3, StartDate = new DateTime(2023, 11, 3), EndDate = new DateTime(2023, 11, 6), Type = "Tiết kiệm", Cost = 2800000, Pics = "bentre.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 10, Name = "Tour Cà Mau - Mũi Cà Mau", Duration = 3, StartDate = new DateTime(2023, 12, 25), EndDate = new DateTime(2023, 12, 28), Type = "Cao cấp", Cost = 8000000, Pics = "camau.jpg", TourGuideId = 1, TransportationMethod = "Máy bay" },
                new Tour { Id = 11, Name = "Tour Tây Nguyên - Buôn Ma Thuột", Duration = 4, StartDate = new DateTime(2024, 1, 15), EndDate = new DateTime(2024, 1, 19), Type = "Cao cấp", Cost = 6000000, Pics = "taynguyen.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 12, Name = "Tour Mộc Châu - Cao nguyên xanh", Duration = 3, StartDate = new DateTime(2024, 2, 20), EndDate = new DateTime(2024, 2, 23), Type = "Tiêu chuẩn", Cost = 4500000, Pics = "mocchau.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 13, Name = "Tour Vũng Tàu - Biển đẹp", Duration = 2, StartDate = new DateTime(2024, 3, 5), EndDate = new DateTime(2024, 3, 7), Type = "Tiết kiệm", Cost = 3200000, Pics = "vungtau.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 14, Name = "Tour Hà Giang - Cao nguyên đá", Duration = 5, StartDate = new DateTime(2024, 4, 12), EndDate = new DateTime(2024, 4, 17), Type = "Cao cấp", Cost = 7000000, Pics = "hagiang.jpg", TourGuideId = 2, TransportationMethod = "Xe khách" },
                new Tour { Id = 15, Name = "Tour Bình Thuận - Mũi Né", Duration = 3, StartDate = new DateTime(2024, 5, 8), EndDate = new DateTime(2024, 5, 11), Type = "Tiêu chuẩn", Cost = 4800000, Pics = "muine.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 16, Name = "Tour Quảng Bình - Phong Nha Kẻ Bàng", Duration = 4, StartDate = new DateTime(2024, 6, 18), EndDate = new DateTime(2024, 6, 22), Type = "Cao cấp", Cost = 7500000, Pics = "quangbinh.jpg", TourGuideId = 1, TransportationMethod = "Máy bay" },
                new Tour { Id = 17, Name = "Tour Lý Sơn - Đảo thiên đường", Duration = 3, StartDate = new DateTime(2024, 7, 25), EndDate = new DateTime(2024, 7, 28), Type = "Tiết kiệm", Cost = 4000000, Pics = "lyson.jpg", TourGuideId = 2, TransportationMethod = "Tàu thủy" },
                new Tour { Id = 18, Name = "Tour Đồng Tháp - Làng hoa Sa Đéc", Duration = 2, StartDate = new DateTime(2024, 8, 14), EndDate = new DateTime(2024, 8, 16), Type = "Tiêu chuẩn", Cost = 3500000, Pics = "sa-dec.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 19, Name = "Tour Ninh Bình - Tràng An", Duration = 2, StartDate = new DateTime(2024, 9, 10), EndDate = new DateTime(2024, 9, 12), Type = "Cao cấp", Cost = 5200000, Pics = "ninhbinh.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 20, Name = "Tour Côn Đảo - Di tích lịch sử", Duration = 3, StartDate = new DateTime(2024, 10, 22), EndDate = new DateTime(2024, 10, 25), Type = "Cao cấp", Cost = 8500000, Pics = "condao.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 21, Name = "Tour Sapa - Núi Fansipan", Duration = 4, StartDate = new DateTime(2024, 11, 5), EndDate = new DateTime(2024, 11, 9), Type = "Cao cấp", Cost = 6500000, Pics = "sapa.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 22, Name = "Tour Huế - Cố đô", Duration = 3, StartDate = new DateTime(2024, 12, 15), EndDate = new DateTime(2024, 12, 18), Type = "Tiêu chuẩn", Cost = 5000000, Pics = "hue.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 23, Name = "Tour Cà Mau - Mũi Cà Mau", Duration = 5, StartDate = new DateTime(2025, 1, 20), EndDate = new DateTime(2025, 1, 25), Type = "Cao cấp", Cost = 7000000, Pics = "camau.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 24, Name = "Tour Đà Lạt - Thành phố ngàn hoa", Duration = 3, StartDate = new DateTime(2025, 2, 12), EndDate = new DateTime(2025, 2, 15), Type = "Tiết kiệm", Cost = 4000000, Pics = "dalat.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 25, Name = "Tour Nha Trang - Đảo Bình Ba", Duration = 4, StartDate = new DateTime(2025, 3, 5), EndDate = new DateTime(2025, 3, 9), Type = "Cao cấp", Cost = 7500000, Pics = "nhatrang.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 26, Name = "Tour Hà Tiên - Biển đảo", Duration = 3, StartDate = new DateTime(2023, 7, 18), EndDate = new DateTime(2023, 7, 21), Type = "Tiêu chuẩn", Cost = 4800000, Pics = "hatien.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 27, Name = "Tour Tây Ninh - Núi Bà Đen", Duration = 2, StartDate = new DateTime(2023, 6, 10), EndDate = new DateTime(2023, 6, 12), Type = "Tiết kiệm", Cost = 3000000, Pics = "tayninh.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" },
                new Tour { Id = 28, Name = "Tour Quy Nhơn - Eo Gió", Duration = 4, StartDate = new DateTime(2023, 5, 25), EndDate = new DateTime(2023, 5, 29), Type = "Cao cấp", Cost = 6800000, Pics = "quynhon.jpg", TourGuideId = 2, TransportationMethod = "Máy bay" },
                new Tour { Id = 29, Name = "Tour Cần Thơ - Chợ nổi Cái Răng", Duration = 2, StartDate = new DateTime(2023, 4, 8), EndDate = new DateTime(2023, 4, 10), Type = "Tiết kiệm", Cost = 3500000, Pics = "cantho.jpg", TourGuideId = 1, TransportationMethod = "Xe khách" },
                new Tour { Id = 30, Name = "Tour Bắc Kạn - Hồ Ba Bể", Duration = 3, StartDate = new DateTime(2023, 3, 3), EndDate = new DateTime(2023, 3, 6), Type = "Tiêu chuẩn", Cost = 4200000, Pics = "babebe.jpg", TourGuideId = 3, TransportationMethod = "Xe khách" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "admin",
                    Role = "admin"
                },
                new User
                {
                    Id = 2,
                    UserName = "nhanvien",
                    Password = "nhanvien",
                    Role = "employee"
                },
                new User
                {
                    Id = 3,
                    UserName = "nhanvien1",
                    Password = "nhanvien1",
                    Role = "employee"
                }
            );

            modelBuilder.Entity<TourOrder>().HasData(
                // 80 TourOrder "Complete" từ 2023 đến đầu 2025
                new TourOrder { Id = 1, CreationTime = new DateTime(2023, 1, 5, 9, 0, 0), Status = "Complete", CustomerID = 1, TourID = 1 },
                new TourOrder { Id = 2, CreationTime = new DateTime(2023, 1, 15, 14, 30, 0), Status = "Complete", CustomerID = 2, TourID = 2 },
                new TourOrder { Id = 3, CreationTime = new DateTime(2023, 2, 1, 10, 15, 0), Status = "Complete", CustomerID = 3, TourID = 3 },
                new TourOrder { Id = 4, CreationTime = new DateTime(2023, 2, 15, 16, 45, 0), Status = "Complete", CustomerID = 4, TourID = 4 },
                new TourOrder { Id = 5, CreationTime = new DateTime(2023, 3, 1, 11, 20, 0), Status = "Complete", CustomerID = 5, TourID = 5 },
                new TourOrder { Id = 6, CreationTime = new DateTime(2023, 3, 15, 13, 0, 0), Status = "Complete", CustomerID = 6, TourID = 6 },
                new TourOrder { Id = 7, CreationTime = new DateTime(2023, 4, 1, 15, 30, 0), Status = "Complete", CustomerID = 7, TourID = 7 },
                new TourOrder { Id = 8, CreationTime = new DateTime(2023, 4, 15, 8, 45, 0), Status = "Complete", CustomerID = 8, TourID = 8 },
                new TourOrder { Id = 9, CreationTime = new DateTime(2023, 5, 1, 12, 10, 0), Status = "Complete", CustomerID = 9, TourID = 9 },
                new TourOrder { Id = 10, CreationTime = new DateTime(2023, 5, 15, 17, 0, 0), Status = "Complete", CustomerID = 10, TourID = 10 },
                new TourOrder { Id = 11, CreationTime = new DateTime(2023, 6, 1, 9, 30, 0), Status = "Complete", CustomerID = 11, TourID = 11 },
                new TourOrder { Id = 12, CreationTime = new DateTime(2023, 6, 15, 14, 0, 0), Status = "Complete", CustomerID = 12, TourID = 12 },
                new TourOrder { Id = 13, CreationTime = new DateTime(2023, 7, 1, 10, 45, 0), Status = "Complete", CustomerID = 13, TourID = 13 },
                new TourOrder { Id = 14, CreationTime = new DateTime(2023, 7, 15, 16, 15, 0), Status = "Complete", CustomerID = 14, TourID = 14 },
                new TourOrder { Id = 15, CreationTime = new DateTime(2023, 8, 1, 11, 50, 0), Status = "Complete", CustomerID = 15, TourID = 15 },
                new TourOrder { Id = 16, CreationTime = new DateTime(2023, 8, 15, 13, 20, 0), Status = "Complete", CustomerID = 16, TourID = 16 },
                new TourOrder { Id = 17, CreationTime = new DateTime(2023, 9, 1, 15, 0, 0), Status = "Complete", CustomerID = 17, TourID = 17 },
                new TourOrder { Id = 18, CreationTime = new DateTime(2023, 9, 15, 9, 15, 0), Status = "Complete", CustomerID = 18, TourID = 18 },
                new TourOrder { Id = 19, CreationTime = new DateTime(2023, 10, 1, 12, 30, 0), Status = "Complete", CustomerID = 19, TourID = 19 },
                new TourOrder { Id = 20, CreationTime = new DateTime(2023, 10, 15, 14, 45, 0), Status = "Complete", CustomerID = 20, TourID = 20 },
                new TourOrder { Id = 21, CreationTime = new DateTime(2023, 11, 1, 16, 0, 0), Status = "Complete", CustomerID = 21, TourID = 21 },
                new TourOrder { Id = 22, CreationTime = new DateTime(2023, 11, 15, 10, 30, 0), Status = "Complete", CustomerID = 22, TourID = 22 },
                new TourOrder { Id = 23, CreationTime = new DateTime(2023, 12, 1, 13, 15, 0), Status = "Complete", CustomerID = 23, TourID = 23 },
                new TourOrder { Id = 24, CreationTime = new DateTime(2023, 12, 15, 15, 45, 0), Status = "Complete", CustomerID = 24, TourID = 24 },
                new TourOrder { Id = 25, CreationTime = new DateTime(2024, 1, 1, 9, 0, 0), Status = "Complete", CustomerID = 25, TourID = 25 },
                new TourOrder { Id = 26, CreationTime = new DateTime(2024, 1, 15, 11, 30, 0), Status = "Complete", CustomerID = 26, TourID = 26 },
                new TourOrder { Id = 27, CreationTime = new DateTime(2024, 2, 1, 14, 0, 0), Status = "Complete", CustomerID = 27, TourID = 27 },
                new TourOrder { Id = 28, CreationTime = new DateTime(2024, 2, 15, 16, 15, 0), Status = "Complete", CustomerID = 28, TourID = 28 },
                new TourOrder { Id = 29, CreationTime = new DateTime(2024, 3, 1, 10, 45, 0), Status = "Complete", CustomerID = 29, TourID = 29 },
                new TourOrder { Id = 30, CreationTime = new DateTime(2024, 3, 15, 12, 0, 0), Status = "Complete", CustomerID = 30, TourID = 30 },
                new TourOrder { Id = 31, CreationTime = new DateTime(2024, 4, 1, 14, 30, 0), Status = "Complete", CustomerID = 31, TourID = 1 },
                new TourOrder { Id = 32, CreationTime = new DateTime(2024, 4, 15, 16, 0, 0), Status = "Complete", CustomerID = 32, TourID = 2 },
                new TourOrder { Id = 33, CreationTime = new DateTime(2024, 5, 1, 9, 15, 0), Status = "Complete", CustomerID = 33, TourID = 3 },
                new TourOrder { Id = 34, CreationTime = new DateTime(2024, 5, 15, 11, 45, 0), Status = "Complete", CustomerID = 34, TourID = 4 },
                new TourOrder { Id = 35, CreationTime = new DateTime(2024, 6, 1, 13, 30, 0), Status = "Complete", CustomerID = 35, TourID = 5 },
                new TourOrder { Id = 36, CreationTime = new DateTime(2024, 6, 15, 15, 0, 0), Status = "Complete", CustomerID = 36, TourID = 6 },
                new TourOrder { Id = 37, CreationTime = new DateTime(2024, 7, 1, 10, 0, 0), Status = "Complete", CustomerID = 37, TourID = 7 },
                new TourOrder { Id = 38, CreationTime = new DateTime(2024, 7, 15, 12, 15, 0), Status = "Complete", CustomerID = 38, TourID = 8 },
                new TourOrder { Id = 39, CreationTime = new DateTime(2024, 8, 1, 14, 45, 0), Status = "Complete", CustomerID = 39, TourID = 9 },
                new TourOrder { Id = 40, CreationTime = new DateTime(2024, 8, 15, 16, 30, 0), Status = "Complete", CustomerID = 40, TourID = 10 },
                new TourOrder { Id = 41, CreationTime = new DateTime(2024, 9, 1, 9, 30, 0), Status = "Complete", CustomerID = 41, TourID = 11 },
                new TourOrder { Id = 42, CreationTime = new DateTime(2024, 9, 15, 11, 0, 0), Status = "Complete", CustomerID = 42, TourID = 12 },
                new TourOrder { Id = 43, CreationTime = new DateTime(2024, 10, 1, 13, 15, 0), Status = "Complete", CustomerID = 43, TourID = 13 },
                new TourOrder { Id = 44, CreationTime = new DateTime(2024, 10, 15, 15, 45, 0), Status = "Complete", CustomerID = 44, TourID = 14 },
                new TourOrder { Id = 45, CreationTime = new DateTime(2024, 11, 1, 10, 0, 0), Status = "Complete", CustomerID = 45, TourID = 15 },
                new TourOrder { Id = 46, CreationTime = new DateTime(2024, 11, 15, 12, 30, 0), Status = "Complete", CustomerID = 46, TourID = 16 },
                new TourOrder { Id = 47, CreationTime = new DateTime(2024, 12, 1, 14, 0, 0), Status = "Complete", CustomerID = 47, TourID = 17 },
                new TourOrder { Id = 48, CreationTime = new DateTime(2024, 12, 15, 16, 15, 0), Status = "Complete", CustomerID = 48, TourID = 18 },
                new TourOrder { Id = 49, CreationTime = new DateTime(2025, 1, 1, 9, 45, 0), Status = "Complete", CustomerID = 49, TourID = 19 },
                new TourOrder { Id = 50, CreationTime = new DateTime(2025, 1, 15, 11, 30, 0), Status = "Complete", CustomerID = 50, TourID = 20 },
                new TourOrder { Id = 51, CreationTime = new DateTime(2023, 2, 10, 13, 0, 0), Status = "Complete", CustomerID = 1, TourID = 21 },
                new TourOrder { Id = 52, CreationTime = new DateTime(2023, 3, 20, 15, 15, 0), Status = "Complete", CustomerID = 2, TourID = 22 },
                new TourOrder { Id = 53, CreationTime = new DateTime(2023, 4, 10, 10, 30, 0), Status = "Complete", CustomerID = 3, TourID = 23 },
                new TourOrder { Id = 54, CreationTime = new DateTime(2023, 5, 20, 12, 45, 0), Status = "Complete", CustomerID = 4, TourID = 24 },
                new TourOrder { Id = 55, CreationTime = new DateTime(2023, 6, 10, 14, 0, 0), Status = "Complete", CustomerID = 5, TourID = 25 },
                new TourOrder { Id = 56, CreationTime = new DateTime(2023, 7, 20, 16, 30, 0), Status = "Complete", CustomerID = 6, TourID = 26 },
                new TourOrder { Id = 57, CreationTime = new DateTime(2023, 8, 10, 9, 0, 0), Status = "Complete", CustomerID = 7, TourID = 27 },
                new TourOrder { Id = 58, CreationTime = new DateTime(2023, 9, 20, 11, 15, 0), Status = "Complete", CustomerID = 8, TourID = 28 },
                new TourOrder { Id = 59, CreationTime = new DateTime(2023, 10, 10, 13, 45, 0), Status = "Complete", CustomerID = 9, TourID = 29 },
                new TourOrder { Id = 60, CreationTime = new DateTime(2023, 11, 20, 15, 0, 0), Status = "Complete", CustomerID = 10, TourID = 30 },
                new TourOrder { Id = 61, CreationTime = new DateTime(2023, 12, 10, 10, 30, 0), Status = "Complete", CustomerID = 11, TourID = 1 },
                new TourOrder { Id = 62, CreationTime = new DateTime(2024, 1, 20, 12, 0, 0), Status = "Complete", CustomerID = 12, TourID = 2 },
                new TourOrder { Id = 63, CreationTime = new DateTime(2024, 2, 10, 14, 15, 0), Status = "Complete", CustomerID = 13, TourID = 3 },
                new TourOrder { Id = 64, CreationTime = new DateTime(2024, 3, 20, 16, 45, 0), Status = "Complete", CustomerID = 14, TourID = 4 },
                new TourOrder { Id = 65, CreationTime = new DateTime(2024, 4, 10, 9, 30, 0), Status = "Complete", CustomerID = 15, TourID = 5 },
                new TourOrder { Id = 66, CreationTime = new DateTime(2024, 5, 20, 11, 0, 0), Status = "Complete", CustomerID = 16, TourID = 6 },
                new TourOrder { Id = 67, CreationTime = new DateTime(2024, 6, 10, 13, 15, 0), Status = "Complete", CustomerID = 17, TourID = 7 },
                new TourOrder { Id = 68, CreationTime = new DateTime(2024, 7, 20, 15, 45, 0), Status = "Complete", CustomerID = 18, TourID = 8 },
                new TourOrder { Id = 69, CreationTime = new DateTime(2024, 8, 10, 10, 0, 0), Status = "Complete", CustomerID = 19, TourID = 9 },
                new TourOrder { Id = 70, CreationTime = new DateTime(2024, 9, 20, 12, 30, 0), Status = "Complete", CustomerID = 20, TourID = 10 },
                new TourOrder { Id = 71, CreationTime = new DateTime(2024, 10, 10, 14, 0, 0), Status = "Complete", CustomerID = 21, TourID = 11 },
                new TourOrder { Id = 72, CreationTime = new DateTime(2024, 11, 20, 16, 15, 0), Status = "Complete", CustomerID = 22, TourID = 12 },
                new TourOrder { Id = 73, CreationTime = new DateTime(2024, 12, 10, 9, 45, 0), Status = "Complete", CustomerID = 23, TourID = 13 },
                new TourOrder { Id = 74, CreationTime = new DateTime(2025, 1, 20, 11, 30, 0), Status = "Complete", CustomerID = 24, TourID = 14 },
                new TourOrder { Id = 75, CreationTime = new DateTime(2025, 2, 1, 13, 0, 0), Status = "Complete", CustomerID = 25, TourID = 15 },
                new TourOrder { Id = 76, CreationTime = new DateTime(2025, 2, 15, 15, 15, 0), Status = "Complete", CustomerID = 26, TourID = 16 },
                new TourOrder { Id = 77, CreationTime = new DateTime(2023, 3, 10, 10, 30, 0), Status = "Complete", CustomerID = 27, TourID = 17 },
                new TourOrder { Id = 78, CreationTime = new DateTime(2023, 4, 20, 12, 45, 0), Status = "Complete", CustomerID = 28, TourID = 18 },
                new TourOrder { Id = 79, CreationTime = new DateTime(2023, 5, 10, 14, 0, 0), Status = "Complete", CustomerID = 29, TourID = 19 },
                new TourOrder { Id = 80, CreationTime = new DateTime(2023, 6, 20, 16, 30, 0), Status = "Complete", CustomerID = 30, TourID = 20 },

                // 20 TourOrder "Pending" gần ngày hiện tại (03/2025)
                new TourOrder { Id = 81, CreationTime = new DateTime(2025, 3, 1, 9, 0, 0), Status = "Pending", CustomerID = 31, TourID = 21 },
                new TourOrder { Id = 82, CreationTime = new DateTime(2025, 3, 1, 11, 30, 0), Status = "Pending", CustomerID = 32, TourID = 22 },
                new TourOrder { Id = 83, CreationTime = new DateTime(2025, 3, 2, 14, 0, 0), Status = "Pending", CustomerID = 33, TourID = 23 },
                new TourOrder { Id = 84, CreationTime = new DateTime(2025, 3, 2, 16, 15, 0), Status = "Pending", CustomerID = 34, TourID = 24 },
                new TourOrder { Id = 85, CreationTime = new DateTime(2025, 3, 3, 9, 45, 0), Status = "Pending", CustomerID = 35, TourID = 25 },
                new TourOrder { Id = 86, CreationTime = new DateTime(2025, 3, 3, 11, 0, 0), Status = "Pending", CustomerID = 36, TourID = 26 },
                new TourOrder { Id = 87, CreationTime = new DateTime(2025, 3, 4, 13, 15, 0), Status = "Pending", CustomerID = 37, TourID = 27 },
                new TourOrder { Id = 88, CreationTime = new DateTime(2025, 3, 4, 15, 30, 0), Status = "Pending", CustomerID = 38, TourID = 28 },
                new TourOrder { Id = 89, CreationTime = new DateTime(2025, 3, 5, 10, 0, 0), Status = "Pending", CustomerID = 39, TourID = 29 },
                new TourOrder { Id = 90, CreationTime = new DateTime(2025, 3, 5, 12, 30, 0), Status = "Pending", CustomerID = 40, TourID = 30 },
                new TourOrder { Id = 91, CreationTime = new DateTime(2025, 3, 6, 14, 45, 0), Status = "Pending", CustomerID = 41, TourID = 1 },
                new TourOrder { Id = 92, CreationTime = new DateTime(2025, 3, 6, 16, 0, 0), Status = "Pending", CustomerID = 42, TourID = 2 },
                new TourOrder { Id = 93, CreationTime = new DateTime(2025, 3, 7, 9, 15, 0), Status = "Pending", CustomerID = 43, TourID = 3 },
                new TourOrder { Id = 94, CreationTime = new DateTime(2025, 3, 7, 11, 30, 0), Status = "Pending", CustomerID = 44, TourID = 4 },
                new TourOrder { Id = 95, CreationTime = new DateTime(2025, 3, 8, 13, 0, 0), Status = "Pending", CustomerID = 45, TourID = 5 },
                new TourOrder { Id = 96, CreationTime = new DateTime(2025, 3, 8, 15, 45, 0), Status = "Pending", CustomerID = 46, TourID = 6 },
                new TourOrder { Id = 97, CreationTime = new DateTime(2025, 3, 9, 10, 30, 0), Status = "Pending", CustomerID = 47, TourID = 7 },
                new TourOrder { Id = 98, CreationTime = new DateTime(2025, 3, 9, 12, 0, 0), Status = "Pending", CustomerID = 48, TourID = 8 },
                new TourOrder { Id = 99, CreationTime = new DateTime(2025, 3, 9, 14, 15, 0), Status = "Pending", CustomerID = 49, TourID = 9 },
                new TourOrder { Id = 100, CreationTime = new DateTime(2025, 3, 9, 16, 30, 0), Status = "Pending", CustomerID = 50, TourID = 10 }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { Id = 1, amount = 5000000, createdAt = new DateTime(2023, 1, 6, 9, 0, 0), TourOrderID = 1 },
                new Invoice { Id = 2, amount = 7000000, createdAt = new DateTime(2023, 1, 16, 14, 30, 0), TourOrderID = 2 },
                new Invoice { Id = 3, amount = 3000000, createdAt = new DateTime(2023, 2, 2, 10, 15, 0), TourOrderID = 3 },
                new Invoice { Id = 4, amount = 6500000, createdAt = new DateTime(2023, 2, 16, 16, 45, 0), TourOrderID = 4 },
                new Invoice { Id = 5, amount = 4000000, createdAt = new DateTime(2023, 3, 2, 11, 20, 0), TourOrderID = 5 },
                new Invoice { Id = 6, amount = 7500000, createdAt = new DateTime(2023, 3, 16, 13, 0, 0), TourOrderID = 6 },
                new Invoice { Id = 7, amount = 3500000, createdAt = new DateTime(2023, 4, 2, 15, 30, 0), TourOrderID = 7 },
                new Invoice { Id = 8, amount = 4200000, createdAt = new DateTime(2023, 4, 16, 8, 45, 0), TourOrderID = 8 },
                new Invoice { Id = 9, amount = 2800000, createdAt = new DateTime(2023, 5, 2, 12, 10, 0), TourOrderID = 9 },
                new Invoice { Id = 10, amount = 8000000, createdAt = new DateTime(2023, 5, 16, 17, 0, 0), TourOrderID = 10 },
                new Invoice { Id = 11, amount = 6000000, createdAt = new DateTime(2023, 6, 2, 9, 30, 0), TourOrderID = 11 },
                new Invoice { Id = 12, amount = 4500000, createdAt = new DateTime(2023, 6, 16, 14, 0, 0), TourOrderID = 12 },
                new Invoice { Id = 13, amount = 3200000, createdAt = new DateTime(2023, 7, 2, 10, 45, 0), TourOrderID = 13 },
                new Invoice { Id = 14, amount = 7000000, createdAt = new DateTime(2023, 7, 16, 16, 15, 0), TourOrderID = 14 },
                new Invoice { Id = 15, amount = 4800000, createdAt = new DateTime(2023, 8, 2, 11, 50, 0), TourOrderID = 15 },
                new Invoice { Id = 16, amount = 7500000, createdAt = new DateTime(2023, 8, 16, 13, 20, 0), TourOrderID = 16 },
                new Invoice { Id = 17, amount = 4000000, createdAt = new DateTime(2023, 9, 2, 15, 0, 0), TourOrderID = 17 },
                new Invoice { Id = 18, amount = 3500000, createdAt = new DateTime(2023, 9, 16, 9, 15, 0), TourOrderID = 18 },
                new Invoice { Id = 19, amount = 5200000, createdAt = new DateTime(2023, 10, 2, 12, 30, 0), TourOrderID = 19 },
                new Invoice { Id = 20, amount = 8500000, createdAt = new DateTime(2023, 10, 16, 14, 45, 0), TourOrderID = 20 },
                new Invoice { Id = 21, amount = 6500000, createdAt = new DateTime(2023, 11, 2, 16, 0, 0), TourOrderID = 21 },
                new Invoice { Id = 22, amount = 5000000, createdAt = new DateTime(2023, 11, 16, 10, 30, 0), TourOrderID = 22 },
                new Invoice { Id = 23, amount = 7000000, createdAt = new DateTime(2023, 12, 2, 13, 15, 0), TourOrderID = 23 },
                new Invoice { Id = 24, amount = 4000000, createdAt = new DateTime(2023, 12, 16, 15, 45, 0), TourOrderID = 24 },
                new Invoice { Id = 25, amount = 7500000, createdAt = new DateTime(2024, 1, 2, 9, 0, 0), TourOrderID = 25 },
                new Invoice { Id = 26, amount = 4800000, createdAt = new DateTime(2024, 1, 16, 11, 30, 0), TourOrderID = 26 },
                new Invoice { Id = 27, amount = 3000000, createdAt = new DateTime(2024, 2, 2, 14, 0, 0), TourOrderID = 27 },
                new Invoice { Id = 28, amount = 6800000, createdAt = new DateTime(2024, 2, 16, 16, 15, 0), TourOrderID = 28 },
                new Invoice { Id = 29, amount = 3500000, createdAt = new DateTime(2024, 3, 2, 10, 45, 0), TourOrderID = 29 },
                new Invoice { Id = 30, amount = 4200000, createdAt = new DateTime(2024, 3, 16, 12, 0, 0), TourOrderID = 30 },
                new Invoice { Id = 31, amount = 5000000, createdAt = new DateTime(2024, 4, 2, 14, 30, 0), TourOrderID = 31 },
                new Invoice { Id = 32, amount = 7000000, createdAt = new DateTime(2024, 4, 16, 16, 0, 0), TourOrderID = 32 },
                new Invoice { Id = 33, amount = 3000000, createdAt = new DateTime(2024, 5, 2, 9, 15, 0), TourOrderID = 33 },
                new Invoice { Id = 34, amount = 6500000, createdAt = new DateTime(2024, 5, 16, 11, 45, 0), TourOrderID = 34 },
                new Invoice { Id = 35, amount = 4000000, createdAt = new DateTime(2024, 6, 2, 13, 30, 0), TourOrderID = 35 },
                new Invoice { Id = 36, amount = 7500000, createdAt = new DateTime(2024, 6, 16, 15, 0, 0), TourOrderID = 36 },
                new Invoice { Id = 37, amount = 3500000, createdAt = new DateTime(2024, 7, 2, 10, 0, 0), TourOrderID = 37 },
                new Invoice { Id = 38, amount = 4200000, createdAt = new DateTime(2024, 7, 16, 12, 15, 0), TourOrderID = 38 },
                new Invoice { Id = 39, amount = 2800000, createdAt = new DateTime(2024, 8, 2, 14, 45, 0), TourOrderID = 39 },
                new Invoice { Id = 40, amount = 8000000, createdAt = new DateTime(2024, 8, 16, 16, 30, 0), TourOrderID = 40 },
                new Invoice { Id = 41, amount = 6000000, createdAt = new DateTime(2024, 9, 2, 9, 30, 0), TourOrderID = 41 },
                new Invoice { Id = 42, amount = 4500000, createdAt = new DateTime(2024, 9, 16, 11, 0, 0), TourOrderID = 42 },
                new Invoice { Id = 43, amount = 3200000, createdAt = new DateTime(2024, 10, 2, 13, 15, 0), TourOrderID = 43 },
                new Invoice { Id = 44, amount = 7000000, createdAt = new DateTime(2024, 10, 16, 15, 45, 0), TourOrderID = 44 },
                new Invoice { Id = 45, amount = 4800000, createdAt = new DateTime(2024, 11, 2, 10, 0, 0), TourOrderID = 45 },
                new Invoice { Id = 46, amount = 7500000, createdAt = new DateTime(2024, 11, 16, 12, 30, 0), TourOrderID = 46 },
                new Invoice { Id = 47, amount = 4000000, createdAt = new DateTime(2024, 12, 2, 14, 0, 0), TourOrderID = 47 },
                new Invoice { Id = 48, amount = 3500000, createdAt = new DateTime(2024, 12, 16, 16, 15, 0), TourOrderID = 48 },
                new Invoice { Id = 49, amount = 5200000, createdAt = new DateTime(2025, 1, 2, 9, 45, 0), TourOrderID = 49 },
                new Invoice { Id = 50, amount = 8500000, createdAt = new DateTime(2025, 1, 16, 11, 30, 0), TourOrderID = 50 },
                new Invoice { Id = 51, amount = 6500000, createdAt = new DateTime(2023, 2, 11, 13, 0, 0), TourOrderID = 51 },
                new Invoice { Id = 52, amount = 5000000, createdAt = new DateTime(2023, 3, 21, 15, 15, 0), TourOrderID = 52 },
                new Invoice { Id = 53, amount = 7000000, createdAt = new DateTime(2023, 4, 11, 10, 30, 0), TourOrderID = 53 },
                new Invoice { Id = 54, amount = 4000000, createdAt = new DateTime(2023, 5, 21, 12, 45, 0), TourOrderID = 54 },
                new Invoice { Id = 55, amount = 7500000, createdAt = new DateTime(2023, 6, 11, 14, 0, 0), TourOrderID = 55 },
                new Invoice { Id = 56, amount = 4800000, createdAt = new DateTime(2023, 7, 21, 16, 30, 0), TourOrderID = 56 },
                new Invoice { Id = 57, amount = 3000000, createdAt = new DateTime(2023, 8, 11, 9, 0, 0), TourOrderID = 57 },
                new Invoice { Id = 58, amount = 6800000, createdAt = new DateTime(2023, 9, 21, 11, 15, 0), TourOrderID = 58 },
                new Invoice { Id = 59, amount = 3500000, createdAt = new DateTime(2023, 10, 11, 13, 45, 0), TourOrderID = 59 },
                new Invoice { Id = 60, amount = 4200000, createdAt = new DateTime(2023, 11, 21, 15, 0, 0), TourOrderID = 60 },
                new Invoice { Id = 61, amount = 5000000, createdAt = new DateTime(2023, 12, 11, 10, 30, 0), TourOrderID = 61 },
                new Invoice { Id = 62, amount = 7000000, createdAt = new DateTime(2024, 1, 21, 12, 0, 0), TourOrderID = 62 },
                new Invoice { Id = 63, amount = 3000000, createdAt = new DateTime(2024, 2, 11, 14, 15, 0), TourOrderID = 63 },
                new Invoice { Id = 64, amount = 6500000, createdAt = new DateTime(2024, 3, 21, 16, 45, 0), TourOrderID = 64 },
                new Invoice { Id = 65, amount = 4000000, createdAt = new DateTime(2024, 4, 11, 9, 30, 0), TourOrderID = 65 },
                new Invoice { Id = 66, amount = 7500000, createdAt = new DateTime(2024, 5, 21, 11, 0, 0), TourOrderID = 66 },
                new Invoice { Id = 67, amount = 3500000, createdAt = new DateTime(2024, 6, 11, 13, 15, 0), TourOrderID = 67 },
                new Invoice { Id = 68, amount = 4200000, createdAt = new DateTime(2024, 7, 21, 15, 45, 0), TourOrderID = 68 },
                new Invoice { Id = 69, amount = 2800000, createdAt = new DateTime(2024, 8, 11, 10, 0, 0), TourOrderID = 69 },
                new Invoice { Id = 70, amount = 8000000, createdAt = new DateTime(2024, 9, 21, 12, 30, 0), TourOrderID = 70 },
                new Invoice { Id = 71, amount = 6000000, createdAt = new DateTime(2024, 10, 11, 14, 0, 0), TourOrderID = 71 },
                new Invoice { Id = 72, amount = 4500000, createdAt = new DateTime(2024, 11, 21, 16, 15, 0), TourOrderID = 72 },
                new Invoice { Id = 73, amount = 3200000, createdAt = new DateTime(2024, 12, 11, 9, 45, 0), TourOrderID = 73 },
                new Invoice { Id = 74, amount = 7000000, createdAt = new DateTime(2025, 1, 21, 11, 30, 0), TourOrderID = 74 },
                new Invoice { Id = 75, amount = 4800000, createdAt = new DateTime(2025, 2, 2, 13, 0, 0), TourOrderID = 75 },
                new Invoice { Id = 76, amount = 7500000, createdAt = new DateTime(2025, 2, 16, 15, 15, 0), TourOrderID = 76 },
                new Invoice { Id = 77, amount = 4000000, createdAt = new DateTime(2023, 3, 11, 10, 30, 0), TourOrderID = 77 },
                new Invoice { Id = 78, amount = 3500000, createdAt = new DateTime(2023, 4, 21, 12, 45, 0), TourOrderID = 78 },
                new Invoice { Id = 79, amount = 5200000, createdAt = new DateTime(2023, 5, 11, 14, 0, 0), TourOrderID = 79 },
                new Invoice { Id = 80, amount = 8500000, createdAt = new DateTime(2023, 6, 21, 16, 30, 0), TourOrderID = 80 }
            );

            modelBuilder.Entity<TourOrder>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.TourOrders)
            .HasForeignKey(o => o.CustomerID)
            .OnDelete(DeleteBehavior.Cascade); // Tự động xóa các TourOrders nếu xóa Customer
        }

    }
}

