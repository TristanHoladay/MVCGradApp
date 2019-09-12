using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class VehicleResources
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicles { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
