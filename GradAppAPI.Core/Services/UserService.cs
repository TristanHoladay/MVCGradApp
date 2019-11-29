using GradAppAPI.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GradAppAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;
        private readonly IUserRepository _userRepo;

        public UserService(IHttpContextAccessor httpsContext, IUserRepository userRepo)
        {
            _context = httpsContext;
            _userRepo = userRepo;
        }

        public ClaimsPrincipal User
        {
            get
            {
                return _context.HttpContext.User;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        public List<User> GetUsersAsync()
        {
            var users = _userRepo.GetUsersAsync().Result;

            if(users == null)
            {
                throw new ApplicationException("Something went wrong. Cannot get list of users.");
            }

            return users;
        }

    }
}
