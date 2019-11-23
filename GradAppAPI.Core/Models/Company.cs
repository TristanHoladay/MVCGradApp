using System;
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
        public string Status { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<UseTicket> Tickets { get; set; }

    }
}
