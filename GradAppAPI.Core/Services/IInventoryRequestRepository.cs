using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IInventoryRequestRepository
    {
        IEnumerable<InventoryRequest> GetAll();

        IEnumerable<InventoryRequest> getRequestsByCompany(int id);

        IEnumerable<InventoryRequest> getRequestsByUser(string id);

        InventoryRequest GetById(int id);

        InventoryRequest Add(InventoryRequest newInventoryRequest);

        InventoryRequest Update(InventoryRequest updatedInventorRequest);

        Boolean Delete(int id);
    }
}
