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
        public string JobDescription { get; set; }


        public IEnumerable<UseTicket> Tickets { get; set; }

       // public int currentVehicleId { get; set; }
       //public Vehicle CurrentVehicle { get; set; }

        //History of Vehicles used (?)
        //public IEnumerable<Vehicle> VehiclesUsed { get; set; }
    }
}
