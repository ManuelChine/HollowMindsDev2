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
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;
        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }


        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<Measurement> Get()
        {
            return _measurementService.GetAllMeasurement();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Measurement Get(int id)
        {
            return _measurementService.GetByIdMeasurement(id);
        }
        

        [HttpGet("GetLastMeasurement")]
        public IEnumerable<Measurement> GetLastMeasurement()
        {
            return _measurementService.GetLastMeasurement();
        }
        
        /*[HttpGet("GetManyMeasurBySilo/{n} {idSilo}")]
        public IEnumerable<Measurement> GetManyMeasurBySilo(int n, int idSilo)
        {
            return _measurementService.GetManyMeasurBySilo(n, idSilo);
        }*/
        [HttpGet("GetMeasurByTime/{time}")]
        public IEnumerable<Measurement> GetMeasurByTime(DateTime time)
        {
            return _measurementService.GetMeasurByTime(time);
        }
 

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post(Measurement value)
        {
            try
            {
                _measurementService.InsertMeasurement(value);
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
        public IActionResult Put(Measurement value)
        {
            try
            {
                _measurementService.UpdateMeasurement(value);
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
                _measurementService.DeleteMeasurement(id);
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
