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
    public class CompaniesController : Controller
    {

        private readonly ICompanyService _companyService;
        private readonly IInventoryRequestService _requestService;
        private readonly IUseTicketService _ticketService;

        public CompaniesController(ICompanyService companyService, IInventoryRequestService requestService, IUseTicketService ticketService)
        {
            _companyService = companyService;
            _requestService = requestService;
            _ticketService = ticketService;
        }


        // GET: api/companies
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_companyService.GetAll().ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAllCompanies", ex.Message);
                return NotFound(ModelState);
            }
        }

        [Authorize]
        // GET api/companies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_companyService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCompany", ex.Message);
                return NotFound(ModelState);
            }
        }

        [HttpGet("/api/companies/{id}/requests")]
        public IActionResult GetRequests(int id)
        {
            try
            {
                return Ok(_requestService.getRequestsByCompany(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCompany", ex.Message);
                return NotFound(ModelState);
            }
        }

        [HttpGet("/api/companies/{id}/tickets")]
        public IActionResult GetTickets(int id)
        {
            try
            {
                return Ok(_ticketService.getTicketsByCompany(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetCompany", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/companies
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody]CompanyApiModel newCompany)
        {
            try
            {
                Company company = _companyService.Add(newCompany.ToDomainModel());
                return Ok(company.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddCompany", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/companies/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CompanyApiModel updatedCompany)
        {
            try
            {
                Company company = updatedCompany.ToDomainModel();
                company.Id = id;
                company = _companyService.Update(company);
                return Ok(company.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("UpdateCompany", ex.Message);
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
                _companyService.Delete(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("DeleteCompany", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
