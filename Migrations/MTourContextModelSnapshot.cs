﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourManagerment.Data;

#nullable disable

namespace TourManagerment.Migrations
{
    [DbContext(typeof(MTourContext))]
    partial class MTourContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TourManagerment.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TourManagerment.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("TourOrderID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourOrderID")
                        .IsUnique()
                        .HasFilter("[TourOrderID] IS NOT NULL");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TourManagerment.Models.Tour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Pics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TourGuideId")
                        .HasColumnType("int");

                    b.Property<string>("TransportationMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("TourGuideId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourManagerment.Models.TourGuide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TourGuides");
                });

            modelBuilder.Entity("TourManagerment.Models.TourOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TourID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("TourID");

                    b.ToTable("TourOrders");
                });

            modelBuilder.Entity("TourManagerment.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TourManagerment.Models.Invoice", b =>
                {
                    b.HasOne("TourManagerment.Models.TourOrder", "TourOrder")
                        .WithOne("Invoice")
                        .HasForeignKey("TourManagerment.Models.Invoice", "TourOrderID");

                    b.Navigation("TourOrder");
                });

            modelBuilder.Entity("TourManagerment.Models.Tour", b =>
                {
                    b.HasOne("TourManagerment.Models.TourGuide", "TourGuide")
                        .WithMany("Tours")
                        .HasForeignKey("TourGuideId");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("TourManagerment.Models.TourGuide", b =>
                {
                    b.HasOne("TourManagerment.Models.User", "User")
                        .WithOne("TourGuide")
                        .HasForeignKey("TourManagerment.Models.TourGuide", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TourManagerment.Models.TourOrder", b =>
                {
                    b.HasOne("TourManagerment.Models.Customer", "Customer")
                        .WithMany("TourOrders")
                        .HasForeignKey("CustomerID");

                    b.HasOne("TourManagerment.Models.Tour", "Tour")
                        .WithMany("TourOrders")
                        .HasForeignKey("TourID");

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourManagerment.Models.Customer", b =>
                {
                    b.Navigation("TourOrders");
                });

            modelBuilder.Entity("TourManagerment.Models.Tour", b =>
                {
                    b.Navigation("TourOrders");
                });

            modelBuilder.Entity("TourManagerment.Models.TourGuide", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("TourManagerment.Models.TourOrder", b =>
                {
                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("TourManagerment.Models.User", b =>
                {
                    b.Navigation("TourGuide");
                });
#pragma warning restore 612, 618
        }
    }
}
