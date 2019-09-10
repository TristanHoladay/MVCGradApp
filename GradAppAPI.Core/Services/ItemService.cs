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
        public IEnumerable<Item> GetAll()
        {
            return _itemRepo.GetAll();
        }

        public Item Get(int id)
        {
            return _itemRepo.Get(id);
        }

        public Item Add(Item newItem)
        {
            return _itemRepo.Add(newItem);
        }

        public Item Update(Item updatedItem)
        {
            return _itemRepo.Update(updatedItem);
        }

        public void Delete(int id)
        {
            _itemRepo.Delete(id);
        }
    }
}
