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
    public class LimitController : ControllerBase
    {
        private readonly ILimitService _limitService;

        public LimitController(ILimitService limitService)
        {
            _limitService = limitService;
        }

        [HttpGet]
        public IEnumerable<Limit> Get()
        {
            return _limitService.GetAllLimit();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Limit Get(int id)
        {
            return _limitService.GetByIdLimit(id);
        }

        // GET api/<TaskController>/5
        [HttpGet("LimitBySilo/{id}")]
        public Limit LimitBySilo(int id)
        {
            return _limitService.LimitBySilo(id);
        }


        [HttpPost]
        public IActionResult Post(Limit value)
        {
            try
            {
                _limitService.InsertLimit(value);
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
        public IActionResult Put(Limit value)
        {
            try
            {
                _limitService.UpdateLimit(value);
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
                _limitService.DeleteLimit(id);
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
