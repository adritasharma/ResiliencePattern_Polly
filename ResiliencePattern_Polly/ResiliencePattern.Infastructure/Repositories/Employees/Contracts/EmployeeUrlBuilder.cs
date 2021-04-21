using System;
using System.Collections.Generic;
using System.Text;

namespace ResiliencePattern.Infastructure.Repositories.Employees.Contracts
{
    public class EmployeeUrlBuilder
    {
        private readonly UriBuilder _uriBuilder = new UriBuilder();

        public EmployeeUrlBuilder()
        {
            _uriBuilder.Path = ServiceRoutes.Employee.Base;
        }

        public string Build()
        {
            return _uriBuilder.Uri.PathAndQuery;
        }
    }
}
