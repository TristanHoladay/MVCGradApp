using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Vehicle : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }
        public bool CheckedOut { get; set; }

        public IEnumerable<Item> Resources { get; set; }

        public IEnumerable<UserVehicles> UserAccess { get; set; }
    }
}
