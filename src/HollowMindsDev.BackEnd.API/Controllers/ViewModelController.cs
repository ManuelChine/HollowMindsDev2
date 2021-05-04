using HollowMindsDev.BackEnd.Services.Interfaces.ViewModel;
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
    public class ViewModelController : ControllerBase
    {
        private readonly IMeasurementModelService _measurementModelService;
        public ViewModelController(IMeasurementModelService measurementModelService)
        {
            _measurementModelService = measurementModelService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public List<MeasurementModel> Get()
        {
            return _measurementModelService.GetAllModel();
        }
    }
}
