using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {

        private readonly AppDbContext _dbContext;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Item> GetAll()
        {
            IEnumerable<Item> itemList = _dbContext.Items.ToList();

            if (itemList == null)
                return null;

            return itemList;
        }

        public Item Get(int id)
        {
            Item item = _dbContext.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return null;

            return item;
        }

        public Item Add(Item newItem)
        {
            Item item = _dbContext.Items.FirstOrDefault(i => i.Id == newItem.Id);

            if (item != null)
                return null;

            _dbContext.Items.Add(newItem);
            _dbContext.SaveChanges();

            return newItem;
        }

        public Item Update(Item updatedItem)
        {
            Item currentItem = _dbContext.Items.FirstOrDefault(i => i.Id == updatedItem.Id);

            if (currentItem == null)
                return null;

            _dbContext.Entry(currentItem)
                .CurrentValues
                .SetValues(updatedItem);

            _dbContext.Items.Update(currentItem);
            _dbContext.SaveChanges();

            return currentItem;
        }

        public void Delete(int id)
        {
            Item delItem = Get(id);

            if (delItem == null) return;

            _dbContext.Items.Remove(delItem);
            _dbContext.SaveChanges();
        }
    }
}
