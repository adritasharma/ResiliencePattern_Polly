using ResiliencePattern.Infastructure.Entities;
using ResiliencePattern.Infastructure.Repositories.Employees;
using ResiliencePattern.Infastructure.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Infastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IPostRepository _postRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public SampleRepository(IPostRepository postRepository, IEmployeeRepository employeeRepository)
        {
            _postRepository = postRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<PostEntityModel>> GetSomeData()
        {
            return await _postRepository.GetPosts();
        }
        public async Task<IEnumerable<EmployeeEntityModel>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }
    }
}
