using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiliencePattern_Polly.Models
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DOJ { get; set; }
    }
}
