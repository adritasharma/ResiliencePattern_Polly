using RetryPattern.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Core.Services
{
    public interface ISampleService
    {
        public Task<IEnumerable<PostServiceModel>> GetSomeData();

    }
}
