using Activities.Domain;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NativeCityController : ControllerBase
    {
        private readonly INativeCityService _nativeCityService;

        public NativeCityController(INativeCityService nativeCityService)
        {
            _nativeCityService = nativeCityService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NativeCity>>> GetAll()
        {
            return Ok(await _nativeCityService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NativeCity>> GetById(long id)
        {
            return Ok(await _nativeCityService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<NativeCity>> Post(NativeCity item)
        {
            return Ok(await _nativeCityService.PostNativeCity(item));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<NativeCity>> PutNativeCity(int id, NativeCity item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            string message = await _nativeCityService.PutNativeCity(item);

            if (message != string.Empty)
            {
                return BadRequest(message);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NativeCity>> DeleteById(int id)
        {
            var ciudadano = await _nativeCityService.DeleteNativeCity(id);
            if (ciudadano != string.Empty)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
