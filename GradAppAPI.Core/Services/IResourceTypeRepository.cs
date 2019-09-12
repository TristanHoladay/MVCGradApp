using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IResourceTypeRepository
    {
        IEnumerable<ResourceType> GetAll();

        ResourceType Get(int id);

        ResourceType Add(ResourceType newRT);

        ResourceType Update(ResourceType updatedRT);

        void Delete(int id);
    }
}
