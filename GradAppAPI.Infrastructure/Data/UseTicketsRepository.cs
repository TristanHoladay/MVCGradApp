using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class UseTicketsRepository : IUseTicketRepository
    {
        private readonly AppDbContext _dbContext;

        public UseTicketsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UseTicket> GetAll()
        {
            IEnumerable<UseTicket> useTicketList = _dbContext.UseTickets.ToList();

            if (useTicketList == null)
                return null;

            return _dbContext.UseTickets
                .Include(ut => ut.User)
                .Include(ut => ut.Company)
                .Include(ut => ut.UsedItems.ToList())
                .ToList();
        }

        public UseTicket GetById(int id)
        {
            UseTicket useTicket = _dbContext.UseTickets.FirstOrDefault(ut => ut.Id == id);

            if (useTicket == null)
                return null;

            return _dbContext.UseTickets
                .Include(ut => ut.User)
                .Include(ut => ut.Company)
                .Include(ut => ut.UsedItems.ToList())
                .FirstOrDefault(ut => ut.Id == id);
        }

        public UseTicket Add(UseTicket newUseTicket)
        {
            UseTicket useTicketCheck = _dbContext.UseTickets.FirstOrDefault(ut => ut.Id == newUseTicket.Id);

            if (useTicketCheck != null)
                return null;

            _dbContext.UseTickets.Add(newUseTicket);
            _dbContext.SaveChanges();

            return newUseTicket;
        }

        public UseTicket Update(UseTicket updatedUseTicket)
        {
            UseTicket currentTicket = _dbContext.UseTickets.FirstOrDefault(ut => ut.Id == updatedUseTicket.Id);

            if (currentTicket == null)
                return null;

            _dbContext.Entry(currentTicket)
                .CurrentValues
                .SetValues(updatedUseTicket);
            _dbContext.UseTickets.Update(currentTicket);
            _dbContext.SaveChanges();

            return currentTicket;
        }

        public bool Delete(int id)
        {
            UseTicket delTicket = GetById(id);

            if (delTicket == null)
                return false;

            _dbContext.Remove(delTicket);
            _dbContext.SaveChanges();

            return true;
        }

    }
}
