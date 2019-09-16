using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IVehicleRepository
    {
        //Get All Vehciles
        IEnumerable<Vehicle> GetAll(int companyId);

        Vehicle Get(int id);

        Vehicle Add(Vehicle newVehicle);

        Vehicle Update(Vehicle updateVehicle);

        void Delete(int Id);
    }
}
