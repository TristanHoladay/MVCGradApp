﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public IEnumerable<Item> Resources { get; set; }
    }
}
