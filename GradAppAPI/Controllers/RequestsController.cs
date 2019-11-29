using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradAppAPI.APIModels;
using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradAppAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class RequestsController : Controller
    {
        private readonly IInventoryRequestService _requestService;

        public RequestsController(IInventoryRequestService requestService)
        {
            _requestService = requestService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<InventoryRequest> requests = _requestService.GetAll();
                return Ok(requests.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllRequestsError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_requestService.GetById(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllRequestsError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]InventoryRequest request)
        {
            try
            {
                InventoryRequest newRequest = _requestService.Add(request);
                return Ok(request.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllRequestsError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]InventoryRequest request)
        {
            try
            {
                InventoryRequest updatedRequest = _requestService.Update(request);
                return Ok(updatedRequest.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllRequestsError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _requestService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllRequestsError", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
