﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Models
{
    public class UseTicket
    {
        public int Id { get; set; }

        //Needs a common number based off the ID? 

        //Ticket Number for ConnectWise Ticket
        public int TISNumber { get; set; }

        //Date UseTicket is created
        public DateTime Date { get; set; }

        //Notes for clarifying details
        public string Notes { get; set; }

        //User who creates the UseTicket
        public int userId { get; set; }
        public User User { get; set; }

        //Company the UseTicket is attached to
        public int companyId { get; set; }
        public Company Company { get; set; }
        

        //Item that was used 
        public int itemId { get; set; }
        public Item Item { get; set; }
    }
}
