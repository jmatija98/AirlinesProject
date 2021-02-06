﻿// <auto-generated />
using System;
using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Airline.Domain.Migrations
{
    [DbContext(typeof(AirlineContext))]
    [Migration("20210206150636_PriceOnFlights")]
    partial class PriceOnFlights
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airline.Domain.Airlines", b =>
                {
                    b.Property<int>("AirlinesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPlanes")
                        .HasColumnType("int");

                    b.Property<int>("YearFounded")
                        .HasColumnType("int");

                    b.HasKey("AirlinesID");

                    b.HasIndex("CountryId");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("Airline.Domain.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Airline.Domain.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("EndDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PilotID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("StartDestination")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightID");

                    b.HasIndex("PilotID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Airline.Domain.Pilot", b =>
                {
                    b.Property<int>("PilotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlinesId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Miles")
                        .HasColumnType("int");

                    b.HasKey("PilotID");

                    b.HasIndex("AirlinesId");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("Airline.Domain.Airlines", b =>
                {
                    b.HasOne("Airline.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airline.Domain.Flight", b =>
                {
                    b.HasOne("Airline.Domain.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airline.Domain.Pilot", b =>
                {
                    b.HasOne("Airline.Domain.Airlines", "Airlines")
                        .WithMany()
                        .HasForeignKey("AirlinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
