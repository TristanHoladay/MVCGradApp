using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUserVehiclesRepository
    {
        IEnumerable<UserVehicles> GetAllByUser(int userId);

        IEnumerable<UserVehicles> GetAllByVehicle(int vehicleId);

        UserVehicles Add(UserVehicles newUserVehicles);

        UserVehicles Update(UserVehicles updatedUserVehicles);

        Boolean Delete(int userId, int vehicleId);
    }
}
