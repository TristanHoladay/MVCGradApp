using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class ResourceTypeApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
