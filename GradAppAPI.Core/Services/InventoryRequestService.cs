using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class InventoryRequestService : IInventoryRequestService
    {
        private readonly IInventoryRequestRepository _inventoryRequestRepo;

        public InventoryRequestService(IInventoryRequestRepository inventoryRequestRepo)
        {
            _inventoryRequestRepo = inventoryRequestRepo;
        }

        public IEnumerable<InventoryRequest> GetAll()
        {
            IEnumerable<InventoryRequest> requestList = _inventoryRequestRepo.GetAll();

            if(requestList == null)
            {
                throw new ApplicationException("There are no Inventory Requests to display.");
            }

            return requestList;
        }

        public InventoryRequest GetById(int id)
        {
            InventoryRequest request = _inventoryRequestRepo.GetById(id);

            if (request == null)
            {
                throw new ApplicationException("There is no Inventory Request that matches the given id.");
            }

            return request;
        }

        public InventoryRequest Add(InventoryRequest newInventoryRequest)
        {
            InventoryRequest newRequest = _inventoryRequestRepo.Add(newInventoryRequest);

            if(newRequest == null)
            {
                throw new ApplicationException("That request already exists.");
            }

            return newRequest;
        }

        public InventoryRequest Update(InventoryRequest updatedInventoryRequest)
        {
            InventoryRequest updatedRequest = _inventoryRequestRepo.Update(updatedInventoryRequest);

            if (updatedRequest == null)
            {
                throw new ApplicationException("That request cannot be found.");
            }

            return updatedRequest;
        }

        public void Delete(int id)
        {
            bool deleteRequest = _inventoryRequestRepo.Delete(id);

            if(!deleteRequest)
            {
                throw new ApplicationException("Request could not be deleted.");
            }
        }

    }
}
