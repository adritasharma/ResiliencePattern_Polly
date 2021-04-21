using AutoMapper;
using ResiliencePattern.Core.ServiceModels;
using ResiliencePattern.Infastructure;
using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IMapper _mapper;

        public EmployeeService(ISampleRepository sampleRepository, IMapper mapper)
        {
            _sampleRepository = sampleRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeServiceModel>> GetEmployees()
        {
            var res = await _sampleRepository.GetEmployees();
            return _mapper.Map<IEnumerable<EmployeeEntityModel>, IEnumerable<EmployeeServiceModel>>(res) ;
        }
    }
}
