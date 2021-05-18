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
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;

        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_blockService.GetAllBlock());//200
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
                return Ok(_blockService.GetByIdBlock(id));//200
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
        [HttpGet("BlockBySilo/{id}")]
        public IActionResult BlockBySilo(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_blockService.BlockBySilo(id));//200
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
        public IActionResult Post(Block value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _blockService.InsertBlock(value);
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
        public IActionResult Put(Block value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _blockService.UpdateBlock(value);
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
                _blockService.DeleteBlock(id);
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
