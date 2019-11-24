using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class InventoryRequest : IEntity<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ResourceTypeId { get; set; }
        public ResourceType ResourceType { get; set; }

        public string Details { get; set; }
        public DateTime Date { get; set; }
        public Boolean Complete { get; set; }
    }
}
