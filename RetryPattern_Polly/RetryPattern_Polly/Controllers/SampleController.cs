using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetryPattern.Core.ServiceModels;
using RetryPattern.Core.Services;
using RetryPattern_Polly.Models;

namespace RetryPattern_Polly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        public readonly ISampleService _sampleService;
        private readonly IMapper _mapper;

        public SampleController(ISampleService sampleService, IMapper mapper)
        {
            _sampleService = sampleService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PostVM>> GetSomeData()
        {
            var res = await _sampleService.GetSomeData();
            return Ok(_mapper.Map<IEnumerable<PostServiceModel>, IEnumerable<PostVM>>(res));
        }
    }
}