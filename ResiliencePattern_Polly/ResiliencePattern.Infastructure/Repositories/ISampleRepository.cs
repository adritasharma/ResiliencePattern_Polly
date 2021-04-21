using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Infastructure
{
    public interface ISampleRepository
    {
        public Task<IEnumerable<PostEntityModel>> GetSomeData();
        public Task<IEnumerable<EmployeeEntityModel>> GetEmployees();
    }
}
