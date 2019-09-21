using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI
{
    public class DbInitializer
    {
        private readonly ICompanyRepository _companyRepo;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly IResourceTypeRepository _resourceTypeRepo;
        private readonly IItemRepository _itemRepo;


        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ICompanyRepository companyRepo, IVehicleRepository vehicleRepo, IResourceTypeRepository resourceTypeRepo, IItemRepository itemRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _companyRepo = companyRepo;
            _vehicleRepo = vehicleRepo;
            _resourceTypeRepo = resourceTypeRepo;
            _itemRepo = itemRepo;

        }

        public void Initialize()
        {
            AddAdminUser();
            AddTestUsers();
            AddTestCompanies();
            AddTestVehicles();
            AddTestResourceTypes();
            AddTestItems();
        }

        public void AddTestUsers()
        {
            var testUsers = new[] {
                new
                {
                    Email = "logan@bluelayerit.com",
                    FirstName = "Logan",
                    LastName = "Papa",
                    CompanyId = 1
                },
                new {
                    Email = "brian@bluelayerit.com",
                    FirstName = "Brian",
                    LastName = "Ketchum",
                    CompanyId = 1
                }
            };

            foreach (var user in testUsers)
            {
                CreateUser(user.Email, user.FirstName, user.LastName, user.CompanyId);
            }

        }

        private User CreateUser(string email, string firstName, string lastName, int companyId)
        {
            if (_userManager.FindByNameAsync(email).Result == null)
            {
                User user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    CompanyId = companyId
                };
                // add user
                var result = _userManager.CreateAsync(user, "Testing123!").Result;
                if (result.Succeeded) return user;
            }
            return null;
        }

        public void AddTestCompanies()
        {
            if (_companyRepo.GetAll().Count() > 0) return;

            Company testCompany = new Company
            {

                Name = "Blue Layer IT",
                Type = "Managed Services Provider",
                Status = "Active"
            };

            _companyRepo.Add(testCompany);

        }

        public void AddTestVehicles()
        {
            if (_vehicleRepo.GetAll(1).Count() > 0) return;

            Vehicle testVehicle1 = new Vehicle
            {
                Id = 1,
                Name = "Fleet Vehicle 1",
                Model = "Ford Focus",
                LicensePlate = "JF3W2-98L",
                Status = "In Use",
                Notes = "ojasodjfowef ojaweofja woeifjo weofjoajoweofj aewofj",
                CompanyId = 1,
                currentUserId = 1,
            };

            Vehicle testVehicle2 = new Vehicle
            {
                Id = 2,
                Name = "Fleet Vehicle 2",
                Model = "Ford Explorer",
                LicensePlate = "KWD2-777",
                Status = "Not In Use",
                Notes = "ojasodjfowef ojaweofja woeifjo weofjoajoweofj aewofj",
                CompanyId = 1,
                currentUserId = 2,
            };

            _vehicleRepo.Add(testVehicle1);
            _vehicleRepo.Add(testVehicle2);
        }

        public void AddTestResourceTypes()
        {
            if (_resourceTypeRepo.GetAll(1).Count() > 0) return;

            ResourceType testType1 = new ResourceType
            {
                Id = 1,
                Name = "Cable",
                CompanyId = 1,
            };

            ResourceType testType2 = new ResourceType
            {
                Id = 2,
                Name = "Ports",
                CompanyId = 1,
            };

            _resourceTypeRepo.Add(testType1);
            _resourceTypeRepo.Add(testType2);
        }

        public void AddTestItems()
        {
            if (_itemRepo.GetAll(1).Count() > 0) return;

            Item testItem1 = new Item
            {
                Id = 1,
                Name = "CAT-5 Cable",
                Description = "Ethernet Cable for desktops, printers, and servers.",
                Amount = 30,
                Cost = 1,
                TypeId = 1,
                VehicleId = 1
            };

            Item testItem2 = new Item
            {
                Id = 2,
                Name = "USB 3.0",
                Description = "USB 3.0 ports for desktops, laptops, printers, and servers.",
                Amount = 22,
                Cost = 5,
                TypeId = 2,
                VehicleId = 2
            };

            _itemRepo.Add(testItem1);
            _itemRepo.Add(testItem2);
        }



        private void AddAdminUser()
        {
            // create an Admin role, if it doesn't already exist
            if (_roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = _roleManager.CreateAsync(adminRole).Result;
            }

            var user = CreateUser("admin@test.com", "admin", "admin", 1);
            if (user != null)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
            //create an Admin user, if it doesn't already exist
            if (_userManager.FindByNameAsync("admin").Result == null)
            {
                User admin = new User
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };

                // add the Admin user to the Admin role
                IdentityResult result = _userManager.CreateAsync(admin, "AdminPassword123!").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
        }
    }
}