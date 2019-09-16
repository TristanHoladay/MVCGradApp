using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _dbContext;

        public VehicleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get All Vehicles
        public IEnumerable<Vehicle> GetAll(int companyId)
        {
            IEnumerable<Vehicle> vehicleList = _dbContext.Vehicles.Where(v => v.CompanyId == companyId).ToList();

            if (vehicleList == null)
                return null;

            return _dbContext.Vehicles
                .Include(v => v.currentUser)
                .Include(v => v.Company)
                .Where(v => v.CompanyId == companyId)
                .ToList();
        }

        public Vehicle Get(int id)
        {
            Vehicle vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return null;

            return _dbContext.Vehicles
                .Include(v => v.currentUser)
                .Include(v => v.Company)
                .FirstOrDefault(v => v.Id == id);
        }

        public Vehicle Add(Vehicle newVehicle)
        {
            Vehicle vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.LicensePlate == newVehicle.LicensePlate);

            if (vehicle != null)
                return null;

            _dbContext.Vehicles.Add(newVehicle);
            _dbContext.SaveChanges();

            return newVehicle;
        }

        public Vehicle Update(Vehicle updatedVehicle)
        {
            Vehicle currentVehicle = _dbContext.Vehicles.FirstOrDefault(v => v.Id == updatedVehicle.Id);

            if(currentVehicle == null)
                return null;

            _dbContext.Entry(currentVehicle)
                .CurrentValues
                .SetValues(updatedVehicle);

            _dbContext.Vehicles.Update(currentVehicle);
            _dbContext.SaveChanges();

            return currentVehicle;
        }

        public void Delete(int id)
        {
            Vehicle delVehicle = Get(id);

            if (delVehicle == null) return; 

            _dbContext.Remove(delVehicle);
            _dbContext.SaveChanges();
        }
    }
}
