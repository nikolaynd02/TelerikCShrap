﻿// <auto-generated />
using System;
using AspNetCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreDemo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220715101938_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreDemo.Models.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Abv")
                        .HasColumnType("float");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                            Abv = 4.5999999999999996,
                            CreatedById = 2,
                            Name = "Glarus English Ale",
                            StyleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Abv = 5.0,
                            CreatedById = 2,
                            Name = "Rhombus Porter",
                            StyleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Abv = 6.5999999999999996,
                            CreatedById = 3,
                            Name = "Opasen Char",
                            StyleId = 3
                        });
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BeerId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeerId = 1,
                            UserId = 3,
                            Value = 5
                        },
                        new
                        {
                            Id = 2,
                            BeerId = 1,
                            UserId = 2,
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            BeerId = 2,
                            UserId = 3,
                            Value = 1
                        },
                        new
                        {
                            Id = 4,
                            BeerId = 2,
                            UserId = 2,
                            Value = 3
                        },
                        new
                        {
                            Id = 5,
                            BeerId = 3,
                            UserId = 3,
                            Value = 5
                        },
                        new
                        {
                            Id = 6,
                            BeerId = 3,
                            UserId = 2,
                            Value = 5
                        });
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Special Ale"
                        },
                        new
                        {
                            Id = 2,
                            Name = "English Porter"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Indian Pale Ale"
                        });
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            IsAdmin = false,
                            Username = "george"
                        },
                        new
                        {
                            Id = 3,
                            IsAdmin = false,
                            Username = "peter"
                        });
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Beer", b =>
                {
                    b.HasOne("AspNetCoreDemo.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreDemo.Models.Style", "Style")
                        .WithMany("Beers")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Style");
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Rating", b =>
                {
                    b.HasOne("AspNetCoreDemo.Models.Beer", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId");

                    b.HasOne("AspNetCoreDemo.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("Beer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Beer", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.Style", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("AspNetCoreDemo.Models.User", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
