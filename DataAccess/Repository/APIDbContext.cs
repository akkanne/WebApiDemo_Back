using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess.Repository
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transports>().ToTable("Transports");
            modelBuilder.Entity<Vehicles>().ToTable("Vehicles");
            modelBuilder.Entity<VehicleTypes>().ToTable("VehicleTypes");
        }

    }
}