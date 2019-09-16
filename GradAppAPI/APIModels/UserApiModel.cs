using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class UserApiModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int currentVehicleId { get; set; }
        public string currentVehicleName { get; set; }
    }
}
