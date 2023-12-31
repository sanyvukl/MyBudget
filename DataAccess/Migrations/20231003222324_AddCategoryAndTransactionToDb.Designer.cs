﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.DataAccess.Data;

#nullable disable

namespace MyBudget.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231003222324_AddCategoryAndTransactionToDb")]
    partial class AddCategoryAndTransactionToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBudget.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "-",
                            Name = "Food",
                            Type = "Expense"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "-",
                            Name = "Travelling",
                            Type = "Expense"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "+",
                            Name = "Work",
                            Type = "Income"
                        });
                });

            modelBuilder.Entity("MyBudget.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 500.0,
                            CategoryId = 2,
                            DateTime = new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2489),
                            Description = "I bought a ticket to Antalya",
                            Title = "Flight to Turkey"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 2000.0,
                            CategoryId = 3,
                            DateTime = new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2537),
                            Description = "I got a salary ",
                            Title = "Got Salary"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 300.0,
                            CategoryId = 1,
                            DateTime = new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2541),
                            Description = "I bought food in costco ",
                            Title = "Costco"
                        });
                });

            modelBuilder.Entity("MyBudget.Models.Transaction", b =>
                {
                    b.HasOne("MyBudget.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
