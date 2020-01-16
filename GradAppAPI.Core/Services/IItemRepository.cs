using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll(int companyId);

        IEnumerable<Item> getItemsByType(int id);

        Item Get(int id);

        Item Add(Item newItem);

        Item Update(Item updatedItem);

        void Delete(int id);
    }
}
