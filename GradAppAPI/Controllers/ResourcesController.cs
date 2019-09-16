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
    public class ResourcesController : Controller
    {

        private readonly IItemService _itemService;

        public ResourcesController(IItemService itemService)
        {
            _itemService = itemService;
        }


        // GET: api/Companies/CompanyId/Resources
        [HttpGet("/api/companies/{companyId}/resources")]
        public IActionResult GetAll(int companyId)
        {
            try
            {
                var companyItems = _itemService.GetAll(companyId);
                return Ok(companyItems.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllCompanyResourceItems", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/resources/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_itemService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetResourceById", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/resources
        [HttpPost]
        public IActionResult Post([FromBody]Item newItem)
        {
            try
            {
                var item = _itemService.Add(newItem);
                return Ok(item.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddResourceItem", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/resources/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Item updatedItem)
        {
            try
            {
                var item = _itemService.Update(updatedItem);
                return Ok(item.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateResourceItem", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/resources/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _itemService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteResourceItem", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
