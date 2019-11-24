using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class UserVehicles : IEntity<int>
    {
        public int Id { get; set; }

        public int userId { get; set; }
        public User User { get; set; }

        public int vehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
