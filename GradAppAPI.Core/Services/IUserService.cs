using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; }

        string CurrentUserId { get; }

        List<User> GetUsers();
    }
}
