using BackEndActivitites.Domain;
using BackEndActivitites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndActivitites.Controllers
{
    [Route("api/[controller]")]
[ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenService _citizenService;

        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetAll()
        {
            return Ok(await _citizenService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetById(long id)
        {
            return Ok(await _citizenService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Citizen>> Post(Citizen item)
        {

            var message = await _citizenService.PostCitizen(item);
            if (!string.IsNullOrEmpty(message))
            {
                return BadRequest(message);
            }
            return CreatedAtAction(nameof(PutCiudadano), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Citizen>> PutCiudadano(int id, Citizen item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            string message = await _citizenService.PutCitizen(item);

            if (message != string.Empty)
            {
                return BadRequest(message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Citizen>> DeleteById(int id)
        {
            var ciudadano = await _citizenService.DeleteCitizen(id);
            if (ciudadano != string.Empty)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
