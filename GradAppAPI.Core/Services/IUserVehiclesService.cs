using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUserVehiclesService
    {
        IEnumerable<UserVehicles> GetAllByUser(int userId);

        UserVehicles GetAllByVehicle(int vehicleId);

        UserVehicles Add(UserVehicles newUserVechicles);

        UserVehicles Update(UserVehicles updatedUserVehicles);

        void Delete(int userId, int vehicleId);




    }
}
