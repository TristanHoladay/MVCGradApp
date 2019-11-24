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
            IEnumerable<Vehicle> vehicles = _vehicleRepo.GetAll();

            if(vehicles == null)
            {
                throw new ApplicationException("There are no vehicles to display");
            }

            return vehicles;
        }

        public Vehicle Get(int id)
        {
            Vehicle vehicle = _vehicleRepo.Get(id);

            if(vehicle == null)
            {
                throw new ApplicationException("That vehicle does not exist.");
            }

            return vehicle;
        }

        public Vehicle Add(Vehicle newVehicle)
        {
            Vehicle newV =  _vehicleRepo.Add(newVehicle);

            if(newV == null)
            {
                throw new ApplicationException("That vehicle already exists. You can't make duplicate entries of the same vehicle");
            }

            return newV;
        }

        public Vehicle Update(Vehicle updatedVehicle)
        {
            Vehicle updatedV = _vehicleRepo.Update(updatedVehicle);

            if(updatedV == null)
            {
                throw new ApplicationException("The vehicle you're trying to update does not exist.");
            }

            return updatedV;
        }

        public void Delete(int id)
        {
            _vehicleRepo.Delete(id);
        }
    }
}
