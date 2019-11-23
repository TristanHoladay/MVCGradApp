using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradAppAPI.Core.Models;

namespace GradAppAPI.APIModels
{
    public static class ResourceTypeMappingExtensions
    {
        public static ResourceTypeApiModel ToApiModel(this ResourceType rt )
        {
            return new ResourceTypeApiModel
            {
                Id = rt.Id,
                Name = rt.Name,
            };
        }

        public static ResourceType ToDomainModel(this ResourceTypeApiModel rtModel)
        {
            return new ResourceType
            {
                Id = rtModel.Id,
                Name = rtModel.Name,
            };
        }

        public static IEnumerable<ResourceTypeApiModel> ToApiModels(this IEnumerable<ResourceType> types)
        {
            return types.Select(t => t.ToApiModel());
        }

        public static IEnumerable<ResourceType> ToDomainModel(this IEnumerable<ResourceTypeApiModel> types)
        {
            return types.Select(t => t.ToDomainModel());
        }
    }
}
