using Microsoft.EntityFrameworkCore;
using System;
using Trucks.Data.Configurations;
using Trucks.Domain.Models;
using Trucks.Domain.Models.Enumerables;

namespace Trucks.Data.Context
{
    /// <summary>
    /// Class to configures the Context to connect with Database through Entity Framework.
    /// </summary>
    public class TrucksAppDbContext
        : DbContext
    {

        public TrucksAppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckConfiguration());

            modelBuilder.Entity<Truck>().HasData(
                new Truck { Id = 1001, Chassis = "2HNYD28507H001989", Model = EnumModel.FH, ModelComplement = "540 GLOBETROTTER 6x4 2p (diesel)", Year = 2010, ModelYear = 2010 },
                new Truck { Id = 1002, Chassis = "JH4DC4466SS977227", Model = EnumModel.FM, Year = 2019, ModelYear = 2020 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
