using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    class User : IdentityUser 
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
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Vehicle> VehiclesUsed { get; set; }
    }
}
