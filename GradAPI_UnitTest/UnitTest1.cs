using GradAppAPI.APIModels;
using GradAppAPI.Core.Models;
using System;
using Xunit;

namespace GradAPI_UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Register_NewUserRegistrationModelShouldReturnOK()
        {
            //controller
            RegistrationModel newUser = new RegistrationModel
            {
                Email = "test@bluelayerit.com",
                Password = "Testing123!",
                FirstName = "Logan",
                LastName = "Papa",
                CompanyId  = 1
            };
        }
    }
}
