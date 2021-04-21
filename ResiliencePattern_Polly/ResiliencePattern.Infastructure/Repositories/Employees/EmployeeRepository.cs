using ResiliencePattern.Infastructure.Entities;
using ResiliencePattern.Infastructure.Repositories.Employees.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace ResiliencePattern.Infastructure.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly EmployeeUrlBuilder _EmployeesUrlBuilder;

        public EmployeeRepository(HttpClient httpClient, EmployeeUrlBuilder EmployeesUrlBuilder)
        {
            _httpClient = httpClient;
            _EmployeesUrlBuilder = EmployeesUrlBuilder;
        }

        public Task<EmployeeEntityModel> GetEmployeeById(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntityModel> GetEmployeeCommentsById(int EmployeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeEntityModel>> GetEmployees()
        {
            string url = _EmployeesUrlBuilder.Build();

            return _httpClient.GetFromJsonAsync<IEnumerable<EmployeeEntityModel>>(url);
        }
    }
}
