﻿using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class UserVehiclesRepository : IUserVehiclesRepository
    {
        private readonly AppDbContext _dbContext;

        public UserVehiclesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserVehicles> GetAllByUser(string usersId)
        {
            IEnumerable<UserVehicles> userVehiclesList = _dbContext.UserVehicles.Where(uv => uv.UserId == usersId);

            if (userVehiclesList == null)
                return null;

            return userVehiclesList;
        }

        public IEnumerable<UserVehicles> GetAllByVehicle(int vehiclesId)
        {
            IEnumerable<UserVehicles> userVehiclesList = _dbContext.UserVehicles.Where(uv => uv.VehicleId == vehiclesId);

            if (userVehiclesList == null)
                return null;

            return userVehiclesList;
        }

        public UserVehicles Add(UserVehicles newUserVehicles)
        {
            UserVehicles userVehiclesCheck = _dbContext.UserVehicles.FirstOrDefault(uv => uv.Id == newUserVehicles.Id);

            if (userVehiclesCheck != null)
                return null;

            _dbContext.UserVehicles.Add(newUserVehicles);
            _dbContext.SaveChanges();

            return newUserVehicles;
        }

        public UserVehicles Update(UserVehicles updatedUserVehicles)
        {
            UserVehicles currentUserVehicles = _dbContext.UserVehicles.FirstOrDefault(uv => uv.Id == updatedUserVehicles.Id);

            if (currentUserVehicles == null)
                return null;

            _dbContext.Entry(currentUserVehicles)
                .CurrentValues
                .SetValues(updatedUserVehicles);
            _dbContext.UserVehicles.Update(currentUserVehicles);
            _dbContext.SaveChanges();

            return updatedUserVehicles;
        }

        public Boolean Delete(int Id)
        {
            UserVehicles delUserVehicles = _dbContext.UserVehicles.FirstOrDefault(uv => uv.Id == Id);

            if (delUserVehicles == null)
                return false;

            _dbContext.UserVehicles.Remove(delUserVehicles);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
