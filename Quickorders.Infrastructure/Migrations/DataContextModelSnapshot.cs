﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quickorders.Infrastructure.Context;

namespace Quickorders.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(127)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(127)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.Property<string>("Name")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("RestaurantNit")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantNit");

                    b.HasIndex("Title", "RestaurantNit")
                        .IsUnique();

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(127)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.OrderProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("PartialPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Owner", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("Name", "MenuId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Restaurant", b =>
                {
                    b.Property<int>("Nit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Nit");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(127)
                        .HasColumnType("varchar(127)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NumberId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("NumberId")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quickorders.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Menu", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("RestaurantNit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Order", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.OrderProduct", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Quickorders.Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Product", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.Menu", "Menu")
                        .WithMany("Products")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Restaurant", b =>
                {
                    b.HasOne("Quickorders.Domain.Entities.Owner", "Owner")
                        .WithMany("Restaurants")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Menu", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.Restaurant", b =>
                {
                    b.Navigation("Menus");
                });

            modelBuilder.Entity("Quickorders.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}