using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Repository.Models;

namespace VehicleManagement.Repository.Repositories
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicle vehicle);
        void SaveChanges();
        IEnumerable<Vehicle> GetVehicleByCustomerId(int customerId);

        Vehicle GetVehicleById(int vehicleId);
        void UpdateVehicle(Vehicle vehicle);


    }

}
