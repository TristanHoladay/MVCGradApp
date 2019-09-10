using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepo = vehicleRepository;
        }

        //GetAll
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicleRepo.GetAll();
        }

        public Vehicle Get(int id)
        {
            return _vehicleRepo.Get(id);
        }

        public Vehicle Add(Vehicle newVehicle)
        {
            return _vehicleRepo.Add(newVehicle);
        }

        public Vehicle Update(Vehicle updatedVehicle)
        {
            return _vehicleRepo.Update(updatedVehicle);
        }

        public void Delete(int id)
        {
            _vehicleRepo.Delete(id);
        }
    }
}
