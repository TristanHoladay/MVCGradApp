﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class VehicleApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string VehicleT { get; set; }

    }
}
