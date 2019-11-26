using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUserVehiclesService
    {
        IEnumerable<UserVehicles> GetAllByUser(string userId);

        IEnumerable<UserVehicles> GetAllByVehicle(int vehicleId);

        UserVehicles Add(UserVehicles newUserVechicles);

        UserVehicles Update(UserVehicles updatedUserVehicles);

        void Delete(string userId, int vehicleId);




    }
}
