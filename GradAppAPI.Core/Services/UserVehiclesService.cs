using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class UserVehiclesService : IUserVehiclesService
    {
        private readonly IUserVehiclesRepository _userVehiclesRepo;

        public UserVehiclesService(IUserVehiclesRepository userVehclesRepo)
        {
            _userVehiclesRepo = userVehclesRepo;
        }

        public IEnumerable<UserVehicles> GetAllByUser(string userId)
        {
            IEnumerable<UserVehicles> userVehiclesList = _userVehiclesRepo.GetAllByUser(userId);

            if (userVehiclesList == null)
            {
                throw new ApplicationException("A list of vehicle relationships do not exist for this user.");
            }

            return userVehiclesList;

        }

        public IEnumerable<UserVehicles> GetAllByVehicle(int vehicleId)
        {
            IEnumerable<UserVehicles> userVehiclesList = _userVehiclesRepo.GetAllByVehicle(vehicleId);

            if (userVehiclesList == null)
            {
                throw new ApplicationException("A list of user relationships do not exist for this vehicle.");
            }

            return userVehiclesList;
        }

        public UserVehicles Add(UserVehicles newUserVehicles)
        {
            if(_userVehiclesRepo.Add(newUserVehicles) == null)
            {
                throw new ApplicationException("Could not create the user-vehicle relationship.");
            }

            return newUserVehicles;
        }

        public UserVehicles Update(UserVehicles newUserVehicles)
        {
            if (_userVehiclesRepo.Add(newUserVehicles) == null)
            {
                throw new ApplicationException("Could not create the user-vehicle relationship.");
            }

            return newUserVehicles;
        }

        public void Delete(int id)
        {
            Boolean delUV = _userVehiclesRepo.Delete(id);
            if (!delUV)
            {
                throw new ApplicationException("Could not find user-vehicle relationship to delete.");
            }
        }
    }
}
