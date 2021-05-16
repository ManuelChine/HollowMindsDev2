using HollowMindsDev.BackEnd.ApplicationCore.Entities.Users;
using HollowMindsDev.BackEnd.Services.Interfaces.IUsers;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_userService.GetByIdUser(id));//200
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
        public IActionResult Post(User value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _userService.InsertUser(value);
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
        public IActionResult Put(User value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                _userService.UpdateUser(value);
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
                _userService.DeleteUser(id);
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

        [HttpGet("IfIsAdmin/{mail}")]
        public IActionResult IfIsAdmin(string mail)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_userService.IfIsAdmin(mail));//200
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
