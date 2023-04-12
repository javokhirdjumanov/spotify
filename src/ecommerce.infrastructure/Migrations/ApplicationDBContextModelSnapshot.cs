﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ecommerce.infrastructure.Persistence;

#nullable disable

namespace ecommerce.infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ecommerce.domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("PostalCode")
                        .HasColumnType("smallint");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Address", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bc56836e-0345-4f01-a883-47f39e32e077"),
                            City = "New York",
                            Country = "USA",
                            PostalCode = (short)4,
                            Region = "Sant Erias",
                            Street = "Elenberg"
                        },
                        new
                        {
                            Id = new Guid("bc56836e-0345-4f01-a883-47f39e32e078"),
                            City = "Madrid",
                            Country = "Spain",
                            PostalCode = (short)3,
                            Region = "Estro",
                            Street = "sant - erias de mucho"
                        });
                });

            modelBuilder.Entity("ecommerce.domain.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("bc56836e-0345-4f01-a883-47f39e32e079"),
                            AddressId = new Guid("bc56836e-0345-4f01-a883-47f39e32e077"),
                            Email = "javokhirdjumanov@gmail.com",
                            Fullname = "Javokhir Djumanov",
                            Password = "7777",
                            Phonenumber = "94 057 77 21",
                            Role = 1,
                            Salt = "ea7ec171-8f1f-43ff-b2ce-cdef13ba8804",
                            Username = "javokhirdjumanov"
                        });
                });

            modelBuilder.Entity("ecommerce.domain.Entities.Users", b =>
                {
                    b.HasOne("ecommerce.domain.Entities.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("ecommerce.domain.Entities.Address", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
