using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class ResourceType : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Item> Resources { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
