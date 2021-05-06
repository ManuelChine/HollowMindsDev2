using HollowMindsDev.BackEnd.Services.Interfaces.Allert;
using HollowMindsDev.BackEnd.Services.ViewModel;
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
    public class AllertController : ControllerBase
    {
        private readonly IAllertService _allertService;

        public AllertController(IAllertService allertService)
        {
            _allertService = allertService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); // 400
                return Ok(_allertService.CreatorAllert());//200
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
