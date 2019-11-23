using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class UserVehicles : IEntity<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vechile { get; set; }
    }
}
