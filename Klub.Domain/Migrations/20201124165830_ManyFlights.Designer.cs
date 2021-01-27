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
    [Migration("20201124165830_ManyFlights")]
    partial class ManyFlights
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Airline.Domain.Airline", b =>
                {
                    b.Property<int>("AirlineID")
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

                    b.HasKey("AirlineID");

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

            modelBuilder.Entity("Airline.Domain.Pilot", b =>
                {
                    b.Property<int>("PilotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Miles")
                        .HasColumnType("int");

                    b.HasKey("PilotID");

                    b.HasIndex("AirlineId");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("Airline.Domain.Airline", b =>
                {
                    b.HasOne("Airline.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Airline.Domain.Pilot", b =>
                {
                    b.HasOne("Airline.Domain.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Airline.Domain.Flight", "Flights", b1 =>
                        {
                            b1.Property<int>("PilotID")
                                .HasColumnType("int");

                            b1.Property<int>("FlightID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<int>("DurationInMinutes")
                                .HasColumnType("int");

                            b1.Property<string>("EndDestination")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("StartDestination")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PilotID", "FlightID");

                            b1.ToTable("Flight");

                            b1.WithOwner()
                                .HasForeignKey("PilotID");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
