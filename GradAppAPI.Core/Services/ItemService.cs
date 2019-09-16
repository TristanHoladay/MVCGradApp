using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepo = itemRepository;
        }

        //GetAll
        public IEnumerable<Item> GetAll(int companyId)
        {
            IEnumerable<Item> resources = _itemRepo.GetAll(companyId);

            if(resources == null)
            {
                throw new ApplicationException("There are no resources to display.");
            }

            return resources;
        }

        public Item Get(int id)
        {
            Item resource = _itemRepo.Get(id);

            if(resource == null)
            {
                throw new ApplicationException("That resource does not exist.");
            }

            return resource;
        }

        public Item Add(Item newItem)
        {
            Item resource = _itemRepo.Add(newItem);

            if(resource == null)
            {
                throw new ApplicationException("That resource already exists. You can't create a duplicate of the same resource.");
            }

            return resource;
        }

        public Item Update(Item updatedItem)
        {
            Item resource =  _itemRepo.Update(updatedItem);

            if(resource == null)
            {
                throw new ApplicationException("The resource you're trying to update doesn't exist.");
            }

            return resource;
        }

        public void Delete(int id)
        {
            _itemRepo.Delete(id);
        }
    }
}
