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

        public List<User> GetUsers()
        {
            var users = _userRepo.GetUsers();

            if(users == null)
            {
                throw new ApplicationException("Something went wrong. Cannot get list of users.");
            }

            return users;
        }

        public User GetUserById(string id)
        {
            User user = _userRepo.GetUserById(id);

            if(user == null)
            {
                throw new ApplicationException("Cannot find user by given id.");
            }

            return user;
        }

        public User Update(User user)
        {
            User updatedUser = _userRepo.Update(user);

            if(updatedUser == null)
            {
                throw new ApplicationException("Could not update user with the given Id.");
            }

            return updatedUser;
        }

        public async Task<IdentityResult> Delete(string id)
        {
            IdentityResult deletedUser = await _userRepo.Delete(id);

            if(!deletedUser.Succeeded)
            {
                throw new ApplicationException("Could not delete the user with the given Id.");
            }

            return deletedUser;
        }

    }
}
