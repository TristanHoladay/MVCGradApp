using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class VehicleMappingExtensions
    {
        public static VehicleApiModel ToApiModel(this Vehicle vehicle)
        {
            return new VehicleApiModel
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Model = vehicle.Model,
                Status = vehicle.Status,
                LicensePlate = vehicle.LicensePlate,
                Notes = vehicle.Notes,
                CompanyId = vehicle.CompanyId,
                CompanyName = vehicle.Company != null
                    ? vehicle.Company.Name
                    : null,
                currentUserId = vehicle.currentUserId,
                currentUserName = vehicle.currentUser != null
                    ? vehicle.currentUser.FullName
                    : null
            };
        }
    }
}
