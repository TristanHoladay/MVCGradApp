using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class UseTicket : IEntity<int>
    {
        //Will act as ticket "number"
        public int Id { get; set; }

        //Ticket Number for ConnectWise Ticket
        public int TISNumber { get; set; }

        //Date UseTicket is created
        public DateTime Date { get; set; }

        //Notes for clarifying details
        public string Notes { get; set; }

        //User who creates the UseTicket
        public string UserId { get; set; }
        public User User { get; set; }

        //Company the UseTicket is attached to
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //Item that was used 
        public IEnumerable<Item> UsedItems { get; set; }
    }
}
