﻿using System;
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
    public class ResourceTypeController : Controller
    {

        private readonly IResourceTypeService _typeService;
        private readonly IItemService _itemService;

        public ResourceTypeController(IResourceTypeService typeService, IItemService itemService)
        {
            _typeService = typeService;
            _itemService = itemService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<ResourceType> types = _typeService.GetAll();
                return Ok(types.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllResourceTypes", ex.Message);
                return NotFound(ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_typeService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetById", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/<controller>/5
        [HttpGet("/api/resourcetype/{id}/items")]
        public IActionResult GetItems(int id)
        {
            try
            {
                return Ok(_itemService.getItemsByType(id));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetById", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ResourceTypeApiModel resourceType)
        {
            try
            {
                ResourceType newType = resourceType.ToDomainModel();
                _typeService.Add(newType);
                return Ok(newType.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("AddTypeError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ResourceType resourceType)
        {
            try
            { 
                var updatedType = _typeService.Update(resourceType);
                return Ok(updatedType);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateResourceTypeError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _typeService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteResourceTypeError", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
