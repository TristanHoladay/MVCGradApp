using GradAppAPI.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GradAppAPI.Core.Services
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUserById(string id);

        User Update(User updatedUser);

        Task<IdentityResult> Delete(string id);
    }
}
