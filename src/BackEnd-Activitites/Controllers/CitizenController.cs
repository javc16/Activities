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
    }
}
