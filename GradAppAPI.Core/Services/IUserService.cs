using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll(int companyId);

        User Get(int id);

        User Add(User newUser);

        User Update(User updatedUser);

        void Delete(int id);
    }
}
