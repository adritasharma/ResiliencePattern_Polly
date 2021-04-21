using ResiliencePattern.Core.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Core.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeServiceModel>> GetEmployees();
    }
}
