﻿using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class CompanyApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CompT { get; set; }
    }

}
