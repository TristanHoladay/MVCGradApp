using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class InventoryRequest : IEntity<int>
    {
        //Id will act as request "number"
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ResourceTypeId { get; set; }
        public ResourceType ResourceType { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Boolean Complete { get; set; }
    }
}
