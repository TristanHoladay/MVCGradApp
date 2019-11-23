using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class ResourceTypeService : IResourceTypeService
    {
        private readonly IResourceTypeRepository _resourceTypeRepo;

        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository)
        {
            _resourceTypeRepo = resourceTypeRepository;
        }

        public IEnumerable<ResourceType> GetAll()
        {
            IEnumerable<ResourceType> types = _resourceTypeRepo.GetAll();

            if (types == null)
            {
                throw new ApplicationException("There are no resource types to display");
            }

            return types;
        }

        public ResourceType Get(int id)
        {
            ResourceType type = _resourceTypeRepo.Get(id);

            if(type == null)
            {
                throw new ApplicationException("That resource type does not exist.");
            }

            return type;
        }

        public ResourceType Add(ResourceType newRT)
        {
            ResourceType newType = _resourceTypeRepo.Add(newRT);

            if(newType == null)
            {
                throw new ApplicationException("That resource type already exists. You can't make a duplicate type.");
            }

            return newType;
        }

        public ResourceType Update(ResourceType updatedRT)
        {
            ResourceType updatedType = _resourceTypeRepo.Update(updatedRT);

            if(updatedType == null)
            {
                throw new ApplicationException("The resource type you're trying to update does not exist.");
            }

            return updatedType;
        }

        public void Delete(int id)
        {
            _resourceTypeRepo.Delete(id);
        }
    }
}
