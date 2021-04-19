using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure
{
    public interface ISampleRepository
    {
        public Task<IEnumerable<PostEntityModel>> GetSomeData();
    }
}
