﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HillarysHaircare.Migrations
{
    [DbContext(typeof(HillarysHaircareDbContext))]
    partial class HillarysHaircareDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HillarysHaircare.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("StylistId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StylistId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Date = new DateOnly(2025, 1, 28),
                            Notes = "First time client, wants layered cut",
                            Status = true,
                            StylistId = 1,
                            Time = new TimeOnly(9, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Date = new DateOnly(2025, 1, 28),
                            Notes = "Regular client - usual style",
                            Status = true,
                            StylistId = 1,
                            Time = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Date = new DateOnly(2025, 1, 28),
                            Notes = "Cancelled due to illness",
                            Status = false,
                            StylistId = 2,
                            Time = new TimeOnly(11, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            Date = new DateOnly(2025, 1, 29),
                            Notes = "Wants to try new color",
                            Status = true,
                            StylistId = 2,
                            Time = new TimeOnly(13, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            Date = new DateOnly(2025, 1, 29),
                            Status = true,
                            StylistId = 1,
                            Time = new TimeOnly(14, 0, 0)
                        });
                });

            modelBuilder.Entity("HillarysHaircare.Models.AppointmentService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ServiceId");

                    b.ToTable("AppointmentServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            ServiceId = 4
                        },
                        new
                        {
                            Id = 3,
                            AppointmentId = 2,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 4,
                            AppointmentId = 4,
                            ServiceId = 1
                        },
                        new
                        {
                            Id = 5,
                            AppointmentId = 4,
                            ServiceId = 2
                        },
                        new
                        {
                            Id = 6,
                            AppointmentId = 5,
                            ServiceId = 3
                        });
                });

            modelBuilder.Entity("HillarysHaircare.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sarah Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Michael Chen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Emma Rodriguez"
                        },
                        new
                        {
                            Id = 4,
                            Name = "James Williams"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lisa Garcia"
                        },
                        new
                        {
                            Id = 6,
                            Name = "David Miller"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Maria Wilson"
                        });
                });

            modelBuilder.Entity("HillarysHaircare.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BasePrice = 30.00m,
                            Name = "Haircut"
                        },
                        new
                        {
                            Id = 2,
                            BasePrice = 100.00m,
                            Name = "Color"
                        },
                        new
                        {
                            Id = 3,
                            BasePrice = 120.00m,
                            Name = "Highlights"
                        },
                        new
                        {
                            Id = 4,
                            BasePrice = 45.00m,
                            Name = "Style"
                        },
                        new
                        {
                            Id = 5,
                            BasePrice = 20.00m,
                            Name = "Beard Trim"
                        });
                });

            modelBuilder.Entity("HillarysHaircare.Models.Stylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stylists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Jessica Smith"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Ryan Brown"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = false,
                            Name = "Amanda Davis"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Carlos Martinez"
                        });
                });

            modelBuilder.Entity("HillarysHaircare.Models.Appointment", b =>
                {
                    b.HasOne("HillarysHaircare.Models.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHaircare.Models.Stylist", "Stylist")
                        .WithMany("Appointments")
                        .HasForeignKey("StylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Stylist");
                });

            modelBuilder.Entity("HillarysHaircare.Models.AppointmentService", b =>
                {
                    b.HasOne("HillarysHaircare.Models.Appointment", "Appointment")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HillarysHaircare.Models.Service", "Service")
                        .WithMany("AppointmentServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HillarysHaircare.Models.Appointment", b =>
                {
                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("HillarysHaircare.Models.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HillarysHaircare.Models.Service", b =>
                {
                    b.Navigation("AppointmentServices");
                });

            modelBuilder.Entity("HillarysHaircare.Models.Stylist", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
