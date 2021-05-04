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
        public List<AllertModel> Get()
        {
            return _allertService.CreatorAllert();
        }
    }
}
