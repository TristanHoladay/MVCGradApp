using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class User : IdentityUser 
    {   
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
               return FirstName + " " + LastName;
            }
        }

        [Required]
        public bool AdminRole { get; set; }

        public string JobDescription { get; set; }


        public IEnumerable<UseTicket> Tickets { get; set; }

        public IEnumerable<InventoryRequest> Requests { get; set; }

       public IEnumerable<UserVehicles> VehicleAccess { get; set; }
    }
}
