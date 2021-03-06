﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GradAppAPI.APIModels;
using GradAppAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GradAppAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [EnableCors("AllowOrigin")]
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }

        //Post api/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            User newUser = new User
            {
                UserName = registration.Email,
                Email = registration.Email,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                AdminRole = registration.AdminRole,
                JobDescription = registration.JobDescription,
            };

            try
            {
                
                var result = await _userManager.CreateAsync(newUser, registration.Password);
                if (newUser.AdminRole)
                {
                    _userManager.AddToRoleAsync(newUser, "Admin").Wait();
                }
                if (result.Succeeded)
                {
                    return Ok(newUser.ToApiModel());
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("RegisterError", e.Message);
            }
            // use UserMager to create a new User. Pass in the password so it can be hashed.
            return BadRequest(ModelState);

        }

        //POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();

            try
            {
                var user = await AuthenticateUserAsync(login.Email, login.Password);

                if (user != null)
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString, email = login.Email });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("LoginError", e.Message);
                return BadRequest(ModelState);
            }
            
            return response;
        }

        private string GenerateJSONWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials);
            return tokenHandler.WriteToken(token);
        }

        private async Task<User> AuthenticateUserAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}