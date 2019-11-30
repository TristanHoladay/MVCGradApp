using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GradAppAPI.Core.Services
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
