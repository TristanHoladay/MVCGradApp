using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class User : IdentityUser 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
               return FirstName + " " + LastName;
            }
        }
        public string JobDescription { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }


        //public IEnumerable<Ticket> Tickets { get; set; }

        public int currentVehicleId { get; set; }
        public Vehicle CurrentVehicle { get; set; }

        //History of Vehicles used (?)
        //public IEnumerable<Vehicle> VehiclesUsed { get; set; }
    }
}
