﻿// <auto-generated />
using System;
using BeerOverflow.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeerOverflow.Migrations
{
    [DbContext(typeof(BeerOverflowDbContext))]
    partial class BeerOverflowDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeerOverflow.Data.Models.BeerDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Abv")
                        .HasColumnType("float");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("StyleId");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abv = 5.0,
                            CreatedById = 1,
                            IsDeleted = false,
                            Name = "Pirinsko",
                            StyleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Abv = 10.0,
                            CreatedById = 2,
                            IsDeleted = false,
                            Name = "Premium",
                            StyleId = 2
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.RatingDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BeerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.StyleDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Draft"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Tester"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "tester@mail.com",
                            FirstName = "Dragan",
                            IsAdmin = false,
                            IsDeleted = false,
                            LastName = "Draganov",
                            Password = "12345",
                            Username = "tester"
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@mail.com",
                            FirstName = "Nikolay",
                            IsAdmin = true,
                            IsDeleted = false,
                            LastName = "Dobrev",
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.BeerDb", b =>
                {
                    b.HasOne("BeerOverflow.Data.Models.UserDb", "CreatedBy")
                        .WithMany("Beers")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Data.Models.StyleDb", "Style")
                        .WithMany("Beers")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.RatingDb", b =>
                {
                    b.HasOne("BeerOverflow.Data.Models.BeerDb", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BeerOverflow.Data.Models.UserDb", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Beer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.BeerDb", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.StyleDb", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("BeerOverflow.Data.Models.UserDb", b =>
                {
                    b.Navigation("Beers");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}