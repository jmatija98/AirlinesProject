using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airline.Domain
{
    public class AirlineContext: DbContext

    {
        public DbSet<Airlines> Airlines { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=AirlinesDatabase;Trusted_connection=true;connect timeout=100;");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilot>(p => p.OwnsMany(f => f.Flights, f => f.ToTable("Flights")));
        }*/


    }


}
