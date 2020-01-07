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
    public class UseTicketsController : Controller
    {
        private readonly IUseTicketService _useTicketService;

        public UseTicketsController(IUseTicketService useTicketService)
        {
            _useTicketService = useTicketService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<UseTicket> tickets = _useTicketService.GetAll();
                return Ok(tickets.ToApiModels());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("GetAllUseTicketsError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_useTicketService.GetById(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetUseTicketError", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UseTicketApiModel useTicket)
        {
            try
            {
                UseTicket newTicket = useTicket.ToDomainModel();
               newTicket = _useTicketService.Add(newTicket);

                return Ok(newTicket.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("CreatUseTicketError", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UseTicketApiModel useTicket)
        {
            try
            {
                UseTicket updatedTicket = useTicket.ToDomainModel();
                updatedTicket.Id = id;

               updatedTicket =  _useTicketService.Update(updatedTicket);
                return Ok(updatedTicket.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateUseTicketError", ex.Message);
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
                _useTicketService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteUseTicketError", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
