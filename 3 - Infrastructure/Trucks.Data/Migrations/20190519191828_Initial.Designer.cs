﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trucks.Data.Context;

namespace Trucks.Data.Migrations
{
    [DbContext(typeof(TrucksAppDbContext))]
    [Migration("20190519191828_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Trucks.Domain.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chassis")
                        .IsRequired()
                        .HasMaxLength(17);

                    b.Property<int>("Model");

                    b.Property<string>("ModelComplement")
                        .HasMaxLength(100);

                    b.Property<int>("ModelYear");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Trucks");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Chassis = "2HNYD28507H001989",
                            Model = 1,
                            ModelComplement = "540 GLOBETROTTER 6x4 2p (diesel)",
                            ModelYear = 2010,
                            Year = 2010
                        },
                        new
                        {
                            Id = 1002,
                            Chassis = "JH4DC4466SS977227",
                            Model = 2,
                            ModelYear = 2020,
                            Year = 2019
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
