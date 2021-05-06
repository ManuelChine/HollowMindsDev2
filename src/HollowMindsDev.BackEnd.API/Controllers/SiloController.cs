using HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiloController : ControllerBase
    {
        private readonly ISiloService _siloService;
        public SiloController(ISiloService siloService)
        {
            _siloService = siloService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_siloService.GetAllSilo());//200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_siloService.GetByIdSilo(id));//200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post(Silo value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _siloService.InsertSilo(value);
                return Ok(new
                {
                    Result = true
                }); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Silo value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _siloService.UpdateSilo(value);
                return Ok(new
                {
                    Result = true
                }); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _siloService.DeleteSilo(id);
                return Ok(new
                {
                    Result = true
                }); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Result = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
