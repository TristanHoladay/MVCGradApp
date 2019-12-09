using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class UserVehiclesApiModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int VehicleId { get; set; }
        public string Vehicle { get; set; }
        public string UvT { get; set; }
    }
}
