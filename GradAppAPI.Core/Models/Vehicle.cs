using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int UserId { get; set; }
        public User currentUser { get; set; }


        public IEnumerable<Item> Resources { get; set; }
    }
}
