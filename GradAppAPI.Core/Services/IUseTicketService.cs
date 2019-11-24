using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUseTicketService
    {
        IEnumerable<UseTicket> GetAll();

        UseTicket GetById(int id);

        UseTicket Add(UseTicket newUseTicket);

        UseTicket Update(UseTicket updatedUseTicket);

        void Delete(int id);
    }
}
