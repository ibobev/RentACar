using CSCB766_RentACar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCB766_RentACar.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Rent>().HasOne(v => v.Vehicle).WithMany(u => u.RentVehicles).HasForeignKey(vi => vi.VehicleId);
            builder.Entity<Rent>().HasOne(v => v.User).WithMany(u => u.RentVehicles).HasForeignKey(vi => vi.UserId);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rent> RentedVehicles { get; set; }
    }
}
