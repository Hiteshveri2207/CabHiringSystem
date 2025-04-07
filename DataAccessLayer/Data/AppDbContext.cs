using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{


    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CustomerProfile> Customer { get; set; }
        public DbSet<DriverProfile> Driver { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<DriverVehicle> DriverVehicle { get; set; }
        public DbSet<VehicleImage> VehicleImage { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
        public DbSet<Car> Cars { get; set; }


    }
}

       