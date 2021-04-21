using ResiliencePattern.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Core.Services
{
    public interface ISampleService
    {
        public Task<IEnumerable<PostServiceModel>> GetSomeData();

    }
}
