using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradAppAPI.APIModels;
using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradAppAPI.Controllers
{
    [Authorize]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<controller>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<User> users = _userService.GetUsers();
                return Ok(users.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetUsersError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/<controller>/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_userService.GetUserById(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetUsersError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {
            try
            {

                return Ok(_userService.Update(user).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetUsersError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _userService.Delete(id);
                return NoContent();
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetUsersError", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
