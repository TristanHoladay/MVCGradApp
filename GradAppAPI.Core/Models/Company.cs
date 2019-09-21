﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Company : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
        public string Status { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Vehicle> VehicleFleet { get; set; }
        public IEnumerable<ResourceType> ResourcesTypes { get; set; }

    }
}
