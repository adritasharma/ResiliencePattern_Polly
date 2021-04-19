using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetryPattern.Infastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        public IEnumerable<Post> GetSomeData()
        {
            throw new NotImplementedException();
        }
    }
}
