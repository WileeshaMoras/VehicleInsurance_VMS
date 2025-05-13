using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleManagement.Repository.Models;


namespace VehicleManagement.Repository.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
