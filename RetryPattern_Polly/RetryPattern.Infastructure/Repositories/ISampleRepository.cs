using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetryPattern.Infastructure
{
    public interface ISampleRepository
    {
        public IEnumerable<Post> GetSomeData();
    }
}
