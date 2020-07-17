﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task2_restAPI.Models;

namespace Task2_restAPI.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20200709155204_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Task2_restAPI.Models.Flat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<float>("LivingArea")
                        .HasColumnType("real");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("int");

                    b.Property<int>("TenantsCount")
                        .HasColumnType("int");

                    b.Property<float>("TotalArea")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("Task2_restAPI.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Task2_restAPI.Models.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DateOfBirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FlatId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Task2_restAPI.Models.Flat", b =>
                {
                    b.HasOne("Task2_restAPI.Models.House", "House")
                        .WithMany("Flats")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Task2_restAPI.Models.Tenant", b =>
                {
                    b.HasOne("Task2_restAPI.Models.Flat", "Flat")
                        .WithMany("Tenants")
                        .HasForeignKey("FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}