using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class ResourceType : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Item> Resources { get; set; }
    }
}
