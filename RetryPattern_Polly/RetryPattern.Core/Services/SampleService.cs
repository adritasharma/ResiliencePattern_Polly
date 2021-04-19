using AutoMapper;
using RetryPattern.Core.ServiceModels;
using RetryPattern.Infastructure;
using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Core.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;
        private readonly IMapper _mapper;

        public SampleService(ISampleRepository sampleRepository, IMapper mapper)
        {
            _sampleRepository = sampleRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PostServiceModel>> GetSomeData()
        {
            var res = await _sampleRepository.GetSomeData();
            return _mapper.Map<IEnumerable<PostEntityModel>, IEnumerable<PostServiceModel>>(res) ;
        }
    }
}
