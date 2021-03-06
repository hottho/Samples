﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiDemo;

namespace WebApiDemo.Migrations
{
    [DbContext(typeof(OrderManagementContext))]
    [Migration("20190723113840_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModel.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("CountryIsoCode")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataModel.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<Guid>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DataModel.OrderHeader", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataModel.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("IsAvailable");

                    b.Property<decimal>("PricePerUom")
                        .HasColumnName("PricePerUom")
                        .HasColumnType("NUMERIC(10,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataModel.OrderDetail", b =>
                {
                    b.HasOne("DataModel.OrderHeader", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataModel.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataModel.OrderHeader", b =>
                {
                    b.HasOne("DataModel.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
