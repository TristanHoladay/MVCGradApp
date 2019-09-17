using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class Item : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }

        //collection of Tickets this resource has been used on
        //public IEnumerable<Ticket> Tickets { get; set; }

        public int TypeId { get; set; }
        public ResourceType ResourceType { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
