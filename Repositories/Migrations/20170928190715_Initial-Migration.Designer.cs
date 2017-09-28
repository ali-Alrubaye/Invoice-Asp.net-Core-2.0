﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Repositories;
using System;

namespace Repositories.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    [Migration("20170928190715_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repositories.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.Property<string>("Picture");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("Repositories.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("OrgNumber");

                    b.Property<string>("Phone");

                    b.Property<string>("Phone2");

                    b.Property<string>("Picture");

                    b.Property<string>("PostCode");

                    b.Property<string>("Region");

                    b.Property<string>("Website");

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Repositories.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int>("CompanyId");

                    b.Property<string>("ContactPerson");

                    b.Property<string>("ContactTitle");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone");

                    b.Property<string>("Phone2");

                    b.Property<string>("PostCode");

                    b.Property<string>("Region");

                    b.HasKey("CustomerId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Repositories.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AdvancePaymentTax");

                    b.Property<int>("CustomerId");

                    b.Property<bool>("IsOffer");

                    b.Property<string>("OfferlDetails");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.Property<bool>("Paid");

                    b.Property<DateTime>("RequiredDate");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Repositories.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Article");

                    b.Property<string>("Notes");

                    b.Property<decimal>("Price");

                    b.Property<short>("Quantity");

                    b.Property<decimal>("Vat");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Repositories.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AdvancePaymentTax");

                    b.Property<string>("Article");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Notes");

                    b.Property<decimal>("Price");

                    b.Property<string>("SupplierName");

                    b.Property<decimal>("Vat");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Repositories.Models.Customer", b =>
                {
                    b.HasOne("Repositories.Models.Company", "Companys")
                        .WithMany("Customers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Repositories.Models.Order", b =>
                {
                    b.HasOne("Repositories.Models.Customer", "CustomerOrders")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Repositories.Models.OrderDetail", b =>
                {
                    b.HasOne("Repositories.Models.Order", "Orders")
                        .WithMany("OrderODs")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Repositories.Models.Product", "Products")
                        .WithMany("ProODs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Repositories.Models.Product", b =>
                {
                    b.HasOne("Repositories.Models.Category", "ProtuctCategorys")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
