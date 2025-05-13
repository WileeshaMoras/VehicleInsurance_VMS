using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Repository.Models;

namespace VehicleManagement.BLL.Services
{
    public interface IVehicleService
    {
        void AddVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> GetVehicleByCustomerId(int customerId);
        Vehicle GetVehicleById(int vehicleId);
        void UpdateVehicle(Vehicle vehicle);
    }
}
