using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradAppAPI.APIModels;
using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradAppAPI.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {

        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        // GET: api/companies/companyId/vehicles
        [HttpGet("/api/companies/companyId/vehicles")]
        public IActionResult GetAll(int companyId)
        {
            try
            {
                return Ok(_vehicleService.GetAll(companyId).ToApiModels());
            }   
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllCompanyVehicles", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/vehicles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_vehicleService.Get(id).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetVehiclebyId", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/vehicles
        [HttpPost]
        public IActionResult Post([FromBody]Vehicle newVehicle)
        {
            try
            {
                return Ok(_vehicleService.Add(newVehicle).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddNewVehicle", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/vehicles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Vehicle updatedVehicle)
        {
            try
            {
                var vehicle = _vehicleService.Update(updatedVehicle);
                return Ok(vehicle.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdatingVehiclebyId", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vehicleService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeletingVehicle", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
