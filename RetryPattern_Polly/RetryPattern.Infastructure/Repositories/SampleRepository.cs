using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        public Task<IEnumerable<PostEntityModel>> GetSomeData()
        {
            throw new NotImplementedException();
        }
    }
}
