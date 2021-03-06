// <auto-generated />
using System;
using CustomerManagementAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CustomerManagementAPI.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20210627163510_Idchanged")]
    partial class Idchanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CustomerManagementAPI.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Items", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<int>("ItemName")
                        .HasColumnType("integer");

                    b.Property<Guid?>("OrdersId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Items", b =>
                {
                    b.HasOne("CustomerManagementAPI.Models.Orders", null)
                        .WithMany("Itsms")
                        .HasForeignKey("OrdersId");
                });

            modelBuilder.Entity("CustomerManagementAPI.Models.Orders", b =>
                {
                    b.Navigation("Itsms");
                });
#pragma warning restore 612, 618
        }
    }
}
