using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class ItemMappingExtensions
    {
        public static ItemApiModel ToApiModel(this Item item)
        {
            return new ItemApiModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Amount = item.Amount,
                Cost = item.Cost,
                TypeId = item.TypeId,
                ResourceTypeName = item.ResourceType.Name,
                companyId = item.companyId,
                Company = item.Company != null
                    ? item.Company.Name
                    : null,
                VehicleId = item.VehicleId,
                VehicleName = item.Vehicle != null
                    ? item.Vehicle.Name
                    : null
            };
        }

        public static Item ToDomainModel(this ItemApiModel itemModel)
        {
            return new Item
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                Description = itemModel.Description,
                Amount = itemModel.Amount,
                Cost = itemModel.Cost,
                TypeId = itemModel.TypeId,
                VehicleId = itemModel.VehicleId
            };
        }

        public static IEnumerable<ItemApiModel> ToApiModels(this IEnumerable<Item> items)
        {
            return items.Select(i => i.ToApiModel());
        }

        public static IEnumerable<Item> ToDomainModels(this IEnumerable<ItemApiModel> items)
        {
            return items.Select(i => i.ToDomainModel());
        }
    }
}
