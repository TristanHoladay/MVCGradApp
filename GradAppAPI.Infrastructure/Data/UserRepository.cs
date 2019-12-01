using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradAppAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserRepository(AppDbContext dbContext, UserManager<User> userManager, PasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public List<User> GetUsers()
        { 
           return _userManager.Users.ToList(); 
        }

        public User GetUserById(string Id)
        {
            User user =_userManager.Users.FirstOrDefault(u => u.Id == Id);

            if (user == null)
                return null;

            return user;
        }

        public User Update(User user)
        {
            User updatedUser = _userManager.Users.FirstOrDefault(u => u.Id == user.Id);

            if (user == null)
                return null;

            updatedUser.Email = user.Email;
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            //need to create method to update claims for user if AdminRole changes
            updatedUser.AdminRole = user.AdminRole;
           // updatedUser.PasswordHash = _passwordHasher.HashPassword(user, user.pass)

            _userManager.UpdateAsync(updatedUser);

            return updatedUser;
        }

        public async Task<IdentityResult> Delete(string id)
        {
            User delUser = GetUserById(id);

            if (delUser == null)
                return null;

           IdentityResult result = await _userManager.DeleteAsync(delUser);

            return result;
        }
    }
}
