using Microsoft.AspNetCore.Mvc;
using VehicleManagement.BLL.Services;
using VehicleManagement.Repository.Models;

namespace VehicleManagemnet.Ui.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add(int customerId)
        {
            var CustomerId = 1;
            ViewBag.customerId = customerId;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vehicle.customerId == 0)
                {
                    vehicle.customerId = 1;
                }
                _vehicleService.AddVehicle(vehicle);
                return RedirectToAction("Success"); // Create this view or route as needed
            }

            return View(vehicle);
        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet]
        public IActionResult View(int customerId)
        {
            var vehicles = _vehicleService.GetVehicleByCustomerId(customerId);
            return View(vehicles);
        }
        [HttpGet]
        public IActionResult Edit(int VehicleId)
        {
            var vehicle = _vehicleService.GetVehicleById(VehicleId);
            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return View(vehicle);
            }
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("View", new { customerId = vehicle.customerId });
            }
            return View(vehicle);
        }
    }
}
