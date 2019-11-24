using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace GradAppAPI.Infrastructure.Data
{
    public class InventoryRequestRepository : IInventoryRequestRepository
    {
        private readonly AppDbContext _dbContext;

        public InventoryRequestRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<InventoryRequest> GetAll()
        {
            IEnumerable<InventoryRequest> requestList = _dbContext.InventoryRequests.ToList();

            if (requestList == null)
                return null;

            return _dbContext.InventoryRequests
                .Include(ir => ir.User)
                .Include(ir => ir.ResourceType)
                .ToList();
        }

        public InventoryRequest GetById(int id)
        {
            InventoryRequest request = _dbContext.InventoryRequests.FirstOrDefault(ir => ir.Id == id);

            if (request == null)
                return null;

            return _dbContext.InventoryRequests
                .Include(ir => ir.User)
                .Include(ir => ir.ResourceType)
                .FirstOrDefault(ir => ir.Id == id);
        }

        public InventoryRequest Add(InventoryRequest newInventoryRequest)
        {
            InventoryRequest requestCheck = _dbContext.InventoryRequests.FirstOrDefault(ir => ir.Id == newInventoryRequest.Id);

            if (requestCheck != null)
                return null;

            _dbContext.InventoryRequests.Add(newInventoryRequest);
            _dbContext.SaveChanges();

            return newInventoryRequest;
        }

        public InventoryRequest Update(InventoryRequest updatedInventoryRequest)
        {
            InventoryRequest currentRequest = _dbContext.InventoryRequests.FirstOrDefault(ir => ir.Id == updatedInventoryRequest.Id);

            if (currentRequest == null)
                return null;

            _dbContext.Entry(currentRequest)
                .CurrentValues
                .SetValues(updatedInventoryRequest);

            _dbContext.InventoryRequests.Update(currentRequest);
            _dbContext.SaveChanges();

            return currentRequest;
        }

        public Boolean Delete(int id)
        {
            InventoryRequest delRequest = GetById(id);

            if (delRequest == null)
                return false;

            _dbContext.InventoryRequests.Remove(delRequest);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
