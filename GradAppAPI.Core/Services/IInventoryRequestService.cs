using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IInventoryRequestService
    {
        IEnumerable<InventoryRequest> GetAll();

        IEnumerable<InventoryRequest> getRequestsByCompany(int id);

        IEnumerable<InventoryRequest> getRequestsByUser(string id);

        InventoryRequest GetById(int id);


        InventoryRequest Add(InventoryRequest newInventoryRequest);

        InventoryRequest Update(InventoryRequest updatedInventoryRequest);

        void Delete(int id);

    }
}
