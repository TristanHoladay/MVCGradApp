using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class ResourceTypeRepository : IResourceTypeRepository  
    {
        private readonly AppDbContext _dbContext;

        public ResourceTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ResourceType> GetAll()
        {
            IEnumerable<ResourceType> types = _dbContext.ResourceTypes;

            if (types == null)
                return null;

            return _dbContext.ResourceTypes.ToList();
        }

        public ResourceType Get(int id)
        {
            ResourceType type = _dbContext.ResourceTypes.FirstOrDefault(rt => rt.Id == id);

            if (type == null)
                return null;

            return _dbContext.ResourceTypes.FirstOrDefault(rt => rt.Id == id);
        }

        public ResourceType Add(ResourceType newRT)
        {
            ResourceType RT = _dbContext.ResourceTypes.FirstOrDefault(rt => rt.Id == newRT.Id);

            if (RT != null)
                return null;

            _dbContext.Add(newRT);
            _dbContext.SaveChanges();

            return newRT;
        }

        public ResourceType Update(ResourceType updatedRT)
        {
            ResourceType currentRT = _dbContext.ResourceTypes.FirstOrDefault(rt => rt.Id == updatedRT.Id);

            if (currentRT == null)
                return null;

            _dbContext.Entry(currentRT)
                .CurrentValues
                .SetValues(updatedRT);

            _dbContext.Update(currentRT);
            _dbContext.SaveChanges();

            return currentRT;
        }

        public void Delete(int id)
        {
            ResourceType delRT = Get(id);

            if (delRT == null) return;

            _dbContext.ResourceTypes.Remove(delRT);
            _dbContext.SaveChanges();
        }
    }
}
