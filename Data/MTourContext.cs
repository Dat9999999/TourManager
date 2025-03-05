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
            //modelBuilder.Entity<Tour>().HasData(
            //    new Tour
            //    {
            //        ID = 1,
            //        Name = "Tour Đà Nẵng - Bà Nà Hills",
            //        Duration = 3,
            //        StartDate = new DateTime(2025, 3, 10),
            //        EndDate = new DateTime(2025, 3, 13),
            //        Type = "Cao cấp",
            //        Cost = 5000000,
            //        Pics = "danang.jpg",
            //        TourGuideId = 1,
            //        TransportationMethod = "Máy bay"
            //    },
            //    new Tour
            //    {
            //        ID = 2,
            //        Name = "Tour Phú Quốc - Biển xanh",
            //        Duration = 4,
            //        StartDate = new DateTime(2025, 4, 5),
            //        EndDate = new DateTime(2025, 4, 9),
            //        Type = "Tiêu chuẩn",
            //        Cost = 7000000,
            //        Pics = "phuquoc.jpg",
            //        TourGuideId = 2,
            //        TransportationMethod = "Máy bay"
            //    },
            //    new Tour
            //    {
            //        ID = 3,
            //        Name = "Tour Hà Nội - Hạ Long",
            //        Duration = 2,
            //        StartDate = new DateTime(2025, 5, 1),
            //        EndDate = new DateTime(2025, 5, 3),
            //        Type = "Tiết kiệm",
            //        Cost = 3000000,
            //        Pics = "halong.jpg",
            //        TourGuideId = 3,
            //        TransportationMethod = "Xe khách"
            //    }
            //);
            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        UserName = "admin",
            //        Password = "admin",
            //        Role = "admin"
            //    },
            //    new User
            //    {
            //        Id = 2,
            //        UserName = "nhanvien",
            //        Password = "nhanvien",
            //        Role = "employee"
            //    }
            //);
        }

    }
}

