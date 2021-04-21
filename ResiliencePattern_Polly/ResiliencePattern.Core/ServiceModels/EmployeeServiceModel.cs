using System;
using System.Collections.Generic;
using System.Text;

namespace ResiliencePattern.Core.ServiceModels
{
    public class EmployeeServiceModel
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DOJ { get; set; }
    }
}
