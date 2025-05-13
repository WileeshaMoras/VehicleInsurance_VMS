using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Repository.Data;
using VehicleManagement.Repository.Models;

namespace VehicleManagement.Repository.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _context;

        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public IEnumerable<Vehicle> GetVehicleByCustomerId(int customerId)
        {
            return _context.Vehicles.Where(v => v.customerId == customerId).ToList();
        }
        public Vehicle GetVehicleById(int vehicleId)
        {
            return _context.Vehicles.FirstOrDefault(v => v.vehicleId == vehicleId);
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
        }
    }
}
