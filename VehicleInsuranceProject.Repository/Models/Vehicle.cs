using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagement.Repository.Models
{
    public class Vehicle
    {
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public string registrationNumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int yearOfManufacture { get; set; }
        public string vehicleType { get; set; }
    }
}
