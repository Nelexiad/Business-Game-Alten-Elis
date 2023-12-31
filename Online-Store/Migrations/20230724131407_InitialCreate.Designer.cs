﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_Store.Models;

#nullable disable

namespace Online_Store.Migrations
{
    [DbContext(typeof(ONLINE_STOREContext))]
    [Migration("20230724131407_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_Store.Models.AvailableProduct", b =>
                {
                    b.Property<int>("IdAvailableProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Available_Product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAvailableProduct"));

                    b.Property<int>("AvailableAmount")
                        .HasColumnType("int")
                        .HasColumnName("Available_Amount");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("ID_Product");

                    b.Property<int>("IdShop")
                        .HasColumnType("int")
                        .HasColumnName("ID_Shop");

                    b.HasKey("IdAvailableProduct");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdShop");

                    b.ToTable("Available_Products", (string)null);
                });

            modelBuilder.Entity("Online_Store.Models.Cart", b =>
                {
                    b.Property<int>("IdCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cart");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCart"));

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("ID_User");

                    b.HasKey("IdCart");

                    b.HasIndex("IdUser");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Online_Store.Models.CartProduct", b =>
                {
                    b.Property<int>("IdCartProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Cart_Product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCartProduct"));

                    b.Property<int>("Amout")
                        .HasColumnType("int");

                    b.Property<int>("IdCart")
                        .HasColumnType("int")
                        .HasColumnName("ID_Cart");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("ID_Product");

                    b.HasKey("IdCartProduct");

                    b.HasIndex("IdCart");

                    b.HasIndex("IdProduct");

                    b.ToTable("Cart_Product", (string)null);
                });

            modelBuilder.Entity("Online_Store.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("IdProduct");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Online_Store.Models.Shop", b =>
                {
                    b.Property<int>("IdShop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Shop");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdShop"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdShop");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Online_Store.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_User");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Online_Store.Models.AvailableProduct", b =>
                {
                    b.HasOne("Online_Store.Models.Product", "IdProductNavigation")
                        .WithMany("AvailableProducts")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK_Available_Products_Product");

                    b.HasOne("Online_Store.Models.Shop", "IdShopNavigation")
                        .WithMany("AvailableProducts")
                        .HasForeignKey("IdShop")
                        .IsRequired()
                        .HasConstraintName("FK_Available_Products_Shop");

                    b.Navigation("IdProductNavigation");

                    b.Navigation("IdShopNavigation");
                });

            modelBuilder.Entity("Online_Store.Models.Cart", b =>
                {
                    b.HasOne("Online_Store.Models.User", "IdUserNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_User");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Online_Store.Models.CartProduct", b =>
                {
                    b.HasOne("Online_Store.Models.Cart", "IdCartNavigation")
                        .WithMany("CartProducts")
                        .HasForeignKey("IdCart")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Cart");

                    b.HasOne("Online_Store.Models.Product", "IdProductNavigation")
                        .WithMany("CartProducts")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Product_Product_Product");

                    b.Navigation("IdCartNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("Online_Store.Models.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Online_Store.Models.Product", b =>
                {
                    b.Navigation("AvailableProducts");

                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("Online_Store.Models.Shop", b =>
                {
                    b.Navigation("AvailableProducts");
                });

            modelBuilder.Entity("Online_Store.Models.User", b =>
                {
                    b.Navigation("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
