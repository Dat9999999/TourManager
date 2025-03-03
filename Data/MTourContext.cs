using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
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

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().HasData(
                new Tour
                {
                    ID = 1,
                    Name = "Tour Đà Nẵng - Bà Nà Hills",
                    Duration = 3,
                    StartDate = new DateTime(2025, 3, 10),
                    EndDate = new DateTime(2025, 3, 13),
                    Type = "Cao cấp",
                    Cost = 5000000,
                    Pics = "danang.jpg",
                    TourGuideID = 1,
                    TransportationMethod = "Máy bay"
                },
                new Tour
                {
                    ID = 2,
                    Name = "Tour Phú Quốc - Biển xanh",
                    Duration = 4,
                    StartDate = new DateTime(2025, 4, 5),
                    EndDate = new DateTime(2025, 4, 9),
                    Type = "Tiêu chuẩn",
                    Cost = 7000000,
                    Pics = "phuquoc.jpg",
                    TourGuideID = 2,
                    TransportationMethod = "Máy bay"
                },
                new Tour
                {
                    ID = 3,
                    Name = "Tour Hà Nội - Hạ Long",
                    Duration = 2,
                    StartDate = new DateTime(2025, 5, 1),
                    EndDate = new DateTime(2025, 5, 3),
                    Type = "Tiết kiệm",
                    Cost = 3000000,
                    Pics = "halong.jpg",
                    TourGuideID = 3,
                    TransportationMethod = "Xe khách"
                }
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
                }
            );
        }

    }
}

