﻿// <auto-generated />
using System;
using AssistCust.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssistCust.Persistance.Migrations
{
    [DbContext(typeof(AssistCustDbContext))]
    partial class AssistCustDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssistCust.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.CompanyShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressField1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AddressField2")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("CompanyId");

                    b.Property<int?>("ManagerId");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ManagerId");

                    b.ToTable("CompanyShops");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyShopId");

                    b.Property<DateTime>("PurchaseTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 9, 22, 9, 59, 54, 302, DateTimeKind.Utc).AddTicks(6));

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.PurchaseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("ProductId");

                    b.Property<int>("PurchaseId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 9, 22, 9, 59, 54, 306, DateTimeKind.Utc).AddTicks(5576));

                    b.Property<string>("Token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.Company", b =>
                {
                    b.HasOne("AssistCust.Domain.Entities.User", "User")
                        .WithMany("Companies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.CompanyShop", b =>
                {
                    b.HasOne("AssistCust.Domain.Entities.Company", "Company")
                        .WithMany("CompanyShops")
                        .HasForeignKey("CompanyId");

                    b.HasOne("AssistCust.Domain.Entities.User", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.Product", b =>
                {
                    b.HasOne("AssistCust.Domain.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.Purchase", b =>
                {
                    b.HasOne("AssistCust.Domain.Entities.CompanyShop", "CompanyShop")
                        .WithMany("Purchases")
                        .HasForeignKey("CompanyShopId");

                    b.HasOne("AssistCust.Domain.Entities.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AssistCust.Domain.Entities.PurchaseDetail", b =>
                {
                    b.HasOne("AssistCust.Domain.Entities.Product", "Product")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("ProductId");

                    b.HasOne("AssistCust.Domain.Entities.Purchase", "Purchase")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
