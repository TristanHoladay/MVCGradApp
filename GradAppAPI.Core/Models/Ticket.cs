using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public User TicketOwner { get; set; }
        public IEnumerable<Item> UsedResources { get; set;}
    }
}
