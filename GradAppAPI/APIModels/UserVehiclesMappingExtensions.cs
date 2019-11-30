using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class UserVehiclesMappingExtensions
    {
        public static UserVehiclesApiModel ToApiModel(this UserVehicles userVehicles)
        {
            return new UserVehiclesApiModel
            {
                Id = userVehicles.Id,
                UserId = userVehicles.UserId,
                UserName = userVehicles.User != null
                    ? userVehicles.User.FullName
                    : null,
                VehicleId = userVehicles.VehicleId,
                Vehicle = userVehicles.Vehicle != null
                    ? userVehicles.Vehicle.Name
                    : null,
            };
        }

        public static UserVehicles ToDomainModel(this UserVehiclesApiModel userVehicles)
        {
            return new UserVehicles
            {
                Id = userVehicles.Id,
                UserId = userVehicles.UserId,
                VehicleId = userVehicles.VehicleId
            };
        }

        public static IEnumerable<UserVehiclesApiModel> ToApiModels(this IEnumerable<UserVehicles> userVehicles)
        {
            return userVehicles.Select(uv => uv.ToApiModel());
        }

        public static IEnumerable<UserVehicles> ToDomainModels(this IEnumerable<UserVehiclesApiModel> userVehicles)
        {
            return userVehicles.Select(uv => uv.ToDomainModel());
        }
    }
}
