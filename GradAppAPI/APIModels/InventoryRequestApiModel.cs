using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class InventoryRequestApiModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public string User { get; set; }

        public int ResourceTypeId { get; set; }
        public string ResourceType { get; set; }

        public int companyId { get; set; }
        public string Company { get; set; }

        public string Details { get; set; }
        public DateTime Date { get; set; }
        public Boolean Complete { get; set; }
    }
}
