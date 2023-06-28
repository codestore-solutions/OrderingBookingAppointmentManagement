﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20230627041343_Added Order and OrderItems Table")]
    partial class AddedOrderandOrderItemsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entitites.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemsId"));

                    b.Property<double>("DeliveryCharges")
                        .HasColumnType("float");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<long?>("VarientId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderItemsId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Entitites.Models.WishlistCollection", b =>
                {
                    b.Property<long>("WishlistCollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("WishlistCollectionId"));

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("WishlistCollectionId");

                    b.ToTable("WishlistCollections");
                });

            modelBuilder.Entity("Entitites.Models.WishlistItems", b =>
                {
                    b.Property<long>("WishlistItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("WishlistItemsId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint");

                    b.Property<long>("VarientId")
                        .HasColumnType("bigint");

                    b.Property<long>("WishListCollectionId")
                        .HasColumnType("bigint");

                    b.HasKey("WishlistItemsId");

                    b.HasIndex("WishListCollectionId");

                    b.ToTable("WishlistItems");
                });

            modelBuilder.Entity("EntityLayer.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AlternateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ShippingAddressId")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ShippingAddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EntityLayer.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EntityLayer.Models.CartItems", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long?>("VarientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EntityLayer.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("PaymentId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShippingAddressId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("orderStatus")
                        .HasColumnType("int");

                    b.Property<int>("paymentMode")
                        .HasColumnType("int");

                    b.Property<int>("paymentStatus")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityLayer.Models.ShippingAddress", b =>
                {
                    b.Property<long>("ShippingAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ShippingAddressId"));

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ShippingAddressId");

                    b.ToTable("ShippngAddress");
                });

            modelBuilder.Entity("Entitites.Models.OrderItems", b =>
                {
                    b.HasOne("EntityLayer.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Entitites.Models.WishlistItems", b =>
                {
                    b.HasOne("Entitites.Models.WishlistCollection", "WishlistCollection")
                        .WithMany("WishlistItems")
                        .HasForeignKey("WishListCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WishlistCollection");
                });

            modelBuilder.Entity("EntityLayer.Models.Address", b =>
                {
                    b.HasOne("EntityLayer.Models.ShippingAddress", "ShippingAddress")
                        .WithMany("Addresss")
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShippingAddress");
                });

            modelBuilder.Entity("EntityLayer.Models.CartItems", b =>
                {
                    b.HasOne("EntityLayer.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Entitites.Models.WishlistCollection", b =>
                {
                    b.Navigation("WishlistItems");
                });

            modelBuilder.Entity("EntityLayer.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("EntityLayer.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EntityLayer.Models.ShippingAddress", b =>
                {
                    b.Navigation("Addresss");
                });
#pragma warning restore 612, 618
        }
    }
}
