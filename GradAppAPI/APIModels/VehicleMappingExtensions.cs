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
            };
        }

        public static Vehicle ToDomainModel(this VehicleApiModel vehicleModel)
        {
            return new Vehicle
            {
                Id = vehicleModel.Id,
                Name = vehicleModel.Name,
                Model = vehicleModel.Model,
                LicensePlate = vehicleModel.LicensePlate,
                Status = vehicleModel.Status,
                Notes = vehicleModel.Notes
            };
        }

        public static IEnumerable<VehicleApiModel> ToApiModels(this IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(v => v.ToApiModel());
        }

        public static IEnumerable<Vehicle> ToDomainModels(this IEnumerable<VehicleApiModel> vehicles)
        {
            return vehicles.Select(v => v.ToDomainModel());
        }
    }
}
