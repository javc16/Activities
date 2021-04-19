﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace BackEnd_Activitites.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]    
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("public")]
        public IActionResult GetPublic()
        {
            var result = new Result("Se llamó al servicio publico de manera satisfactoria.!");
            return Ok(result);
        }

        [HttpGet("private")]
        public IActionResult GetPrivate()
        {
            var result = new Result("Se llamó al servicio privado de manera satisfactoria.!");
            return Ok(result);
        }

        [HttpGet("permission")]
        public IActionResult GetPermissions()
        {
            var result = new Result("Se llamó al servicio privado con permisos de manera satisfactoria.!");
            return Ok(result);
        }

    }
    public class Result
    {
        public Result(string msg)
        {
            this.Msg = msg;
        }
        public string Msg { get; set; }
    }
}
