using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class UserMappingExtensions
    {
        public static UserApiModel ToApiModel(this User user)
        {
            return new UserApiModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Email = user.Email,
                AdminRole = user.AdminRole,
                JobDescription = user.JobDescription  
            };
        }

        public static User ToDomainModel(this UserApiModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                JobDescription = userModel.JobDescription,
                AdminRole = userModel.AdminRole
            };
        }

        public static IEnumerable<UserApiModel> ToApiModels(this IEnumerable<User> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserApiModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
