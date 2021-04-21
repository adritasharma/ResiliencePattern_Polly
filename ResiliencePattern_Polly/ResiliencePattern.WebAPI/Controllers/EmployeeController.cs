using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResiliencePattern.Core.ServiceModels;
using ResiliencePattern.Core.Services;
using ResiliencePattern_Polly.Models;

namespace ResiliencePattern.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<EmployeeVM>> GetSomeData()
        {
            var res = await _employeeService.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeServiceModel>, IEnumerable<EmployeeVM>>(res));
        }
    }
}