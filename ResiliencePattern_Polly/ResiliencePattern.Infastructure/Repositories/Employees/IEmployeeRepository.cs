using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Infastructure.Repositories.Employees
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<EmployeeEntityModel>> GetEmployees();
        public Task<EmployeeEntityModel> GetEmployeeById(int EmployeeId);
        public Task<EmployeeEntityModel> GetEmployeeCommentsById(int EmployeeId);
    }
}
