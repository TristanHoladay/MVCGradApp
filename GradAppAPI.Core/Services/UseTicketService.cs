using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class UseTicketService : IUseTicketService
    {
        private readonly IUseTicketRepository _useTicketRepo;

        public UseTicketService(IUseTicketRepository useTicketRepo)
        {
            _useTicketRepo = useTicketRepo;
        }
        public IEnumerable<UseTicket> GetAll()
        {
            IEnumerable<UseTicket> useTicketList = _useTicketRepo.GetAll();

            if(useTicketList == null)
            {
                throw new ApplicationException("There are no use tickets to display");
            }

            return useTicketList;
        }

        public UseTicket GetById(int id)
        {
            UseTicket useTicket = _useTicketRepo.GetById(id);

            if (useTicket == null)
            {
                throw new ApplicationException("That use ticket does not exist.");
            }

            return useTicket;
        }

        public UseTicket Add(UseTicket newUseTicket)
        {
            UseTicket addedUseTicket = _useTicketRepo.Add(newUseTicket);

            if (addedUseTicket == null)
            {
                throw new ApplicationException("That ticket already exists.");
            }

            return addedUseTicket;
        }

        public UseTicket Update(UseTicket updatedUseTicket)
        {
            UseTicket changedUseTicket = _useTicketRepo.Update(updatedUseTicket);

            if (changedUseTicket == null)
            {
                throw new ApplicationException("That ticket does not exist to be updated.");
            }

            return changedUseTicket;
        }

        public void Delete(int id)
        {
            bool deletedUseTicket = _useTicketRepo.Delete(id);

            if(!deletedUseTicket)
            {
                throw new ApplicationException("Could not delete Use Ticket.");
            }
        }
    }
}
