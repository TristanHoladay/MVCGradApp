using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public class UseTicketApiModel
    {
        public int Id { get; set; }

        public int TISNumber { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }
        public string User { get; set; }

        public int companyId { get; set; }
        public string Company { get; set; }

    }
}
