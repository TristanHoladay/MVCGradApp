using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUseTicketRepository
    {
        IEnumerable<UseTicket> GetAll();

        IEnumerable<UseTicket> getTicketsByCompany(int id);

        IEnumerable<UseTicket> getTicketsByUser(string id);

        UseTicket GetById(int id);

        UseTicket Add(UseTicket newUseTicket);

        UseTicket Update(UseTicket updatedUseTicket);

        Boolean Delete(int id);
    }
}
