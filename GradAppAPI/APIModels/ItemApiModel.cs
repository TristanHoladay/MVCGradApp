using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class ItemApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }

        public int TypeId { get; set; }
        public string ResourceTypeName { get; set; }

        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
    }
}
