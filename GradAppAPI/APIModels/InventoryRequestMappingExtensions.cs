using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class InventoryRequestMappingExtensions
    {
        public static InventoryRequestApiModel ToApiModel(this InventoryRequest request)
        {
            return new InventoryRequestApiModel
            {
                Id = request.Id,
                userId = request.userId,
                User = request.User != null
                    ? request.User.FullName
                    : null,
                companyId = request.CompanyId,
                Company = request.Company != null
                    ? request.Company.Name
                    : null,
                ResourceTypeId = request.ResourceTypeId,
                ResourceType = request.ResourceType != null
                    ? request.ResourceType.Name
                    : null,
                Date = request.Date,
                Details = request.Details,
                Complete = request.Complete
            };
        }

        public static InventoryRequest ToDomainModel(this InventoryRequestApiModel request)
        {
            return new InventoryRequest
            {
                Id = request.Id,
                Date = request.Date,
                Details = request.Details,
                Complete = request.Complete,
                userId = request.userId,
                CompanyId = request.companyId,
                ResourceTypeId = request.ResourceTypeId
            };
        }

        public static IEnumerable<InventoryRequestApiModel> ToApiModels(this IEnumerable<InventoryRequest> requests)
        {
            return requests.Select(r => r.ToApiModel());
        }

        public static IEnumerable<InventoryRequest> ToDomainModels(this IEnumerable<InventoryRequestApiModel> requests)
        {
            return requests.Select(r => r.ToDomainModel());
        }
    }
}
