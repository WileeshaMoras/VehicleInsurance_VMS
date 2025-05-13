using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Repository.Models;
using VehicleManagement.Repository.Repositories;

namespace VehicleManagement.BLL.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle.customerId <= 0)
            {
                throw new ArgumentException("CustomerId is required");
            }
            // Example validation
            if (string.IsNullOrWhiteSpace(vehicle.make) || string.IsNullOrWhiteSpace(vehicle.model))
                throw new ArgumentException("Make and Model are required");

            if (vehicle.yearOfManufacture < 1900 || vehicle.yearOfManufacture > DateTime.Now.Year)
                throw new ArgumentException("Invalid year");

            _repository.AddVehicle(vehicle);
            _repository.SaveChanges();
        }
        public IEnumerable<Vehicle> GetVehicleByCustomerId(int customerId)
        {
            return _repository.GetVehicleByCustomerId(customerId);
        }
        public Vehicle? GetVehicleById(int vehicleId)
        {
            return _repository.GetVehicleById(vehicleId);
        }
        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            var existing = _repository.GetVehicleById(updatedVehicle.vehicleId);
            if (existing == null)
            {
                throw new Exception("Vehicle not Found");
            }
            else
            {
                existing.registrationNumber = updatedVehicle.registrationNumber;
                existing.make = updatedVehicle.make;
                existing.model = updatedVehicle.model;
                existing.yearOfManufacture = updatedVehicle.yearOfManufacture;
                existing.vehicleType = updatedVehicle.vehicleType;


            }
            _repository.UpdateVehicle(existing);
            _repository.SaveChanges();
        }
    }
}
