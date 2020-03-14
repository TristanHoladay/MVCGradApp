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
    [Authorize(AuthenticationSchemes = "Bearer")]
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    public class UserVehiclesController : Controller
    {

        private readonly IUserVehiclesService _uvService;

        public UserVehiclesController(IUserVehiclesService uvService)
        {
            _uvService = uvService;
        }

        // GET: api/<controller>
        [HttpGet("/api/users/{userId}/uservehicles")]
        public IActionResult GetAllByUser(string userId)
        {
            try
            {
                return Ok(_uvService.GetAllByUser(userId).ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllUserVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_uvService.GetAllByVehicle(id).ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllUserVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UserVehiclesApiModel userVehicles)
        {
            try
            {
                var newUV = userVehicles.ToDomainModel();
                newUV = _uvService.Add(newUV);

                return Ok(newUV.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllUserVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserVehiclesApiModel userVehicles)
        {
            try
            {
                var updatedUV = userVehicles.ToDomainModel();
                updatedUV = _uvService.Update(updatedUV);

                return Ok(updatedUV.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllUserVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _uvService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllUserVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
